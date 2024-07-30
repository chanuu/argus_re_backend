using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Configuration;
using Argus.Platform.Core.Customers;
using Argus.Platform.Core.Features;
using Argus.Platform.Core.Identity;
using Argus.Platform.Core.JobEvents;
using Argus.Platform.Core.Jobs;
using Argus.Platform.Core.JobsWorkflowEvents;
using Argus.Platform.Core.Packages;
using Argus.Platform.Core.Subscriptions;
using Argus.Platform.Core.Workflows;
using Argus.Platform.Core.WorkItems;
using Argus.Platform.Infrastructure.Middleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Argus.Platform.Infrastructure.Persistance
{
    public class ApiContext : IdentityDbContext<User, Role, string>, IUnitOfWork
    {
        private readonly ITenantProvider _tenantProvider;
        private readonly IBranchProvider _branchProvider;
        IHttpContextAccessor _context { get; set; }
        public bool ApplyTenantFilter { get; set; } = true;
        public bool ApplyBranchFilter { get; set; } = true;
        public ApiContext(DbContextOptions<ApiContext> options,
             IHttpContextAccessor context,
             ITenantProvider tenantProvider,
             IBranchProvider branchProvider

          ) : base(options)
        {
            _context = context;
            _tenantProvider = tenantProvider;
            _branchProvider = branchProvider;

        }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<AuditTrail> AuditLogs { get; set; }

        public DbSet<Company> Company { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Workflow> Workflows { get; set; }

        public DbSet<Package> Packages { get; set; }
        public DbSet<JobEvent> JobEvents { get; set; }
        public DbSet<WorkItem> WorkItems { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<JobsWorkflowEvent> JobsWorkflowEvents { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Feature> Features { get; set; }


        public DbSet<Tenants> Tenants { get; set; }

        

        void UpdateCrudInfo(EntityEntry entry, AuditLog auditEntry)
        {
            if (entry.State == EntityState.Modified)
            {
                try
                {
                    entry.Property("LastModifiedOn").CurrentValue = DateTime.Now;
                    entry.Property("LastUpdatedBy").CurrentValue = GetCurrentLoogedUser(); 

                }
                catch (Exception ex)
                {

                }

            }
            else if (entry.State == EntityState.Added)
            {
                try
                {

                    entry.Property("CreationTime").CurrentValue = DateTime.Now;
                    Guid _signature = Guid.NewGuid();
                    entry.Property("RecordSignature").CurrentValue = _signature;
                    auditEntry.RecordSignature = _signature;
                    entry.Property("CreatedBy").CurrentValue = GetCurrentLoogedUser();
                    entry.Property("LastModifiedOn").CurrentValue = DateTime.Now;

                }
                catch (Exception ex)
                {

                }

            }
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {


            var entries = ChangeTracker
                .Entries()
                .Where(E => E.State == EntityState.Added || E.State == EntityState.Modified || E.State == EntityState.Deleted)
                .ToList();


            var auditEntries = new List<AuditLog>();
            foreach (var entry in entries)
            {
                if (CurrentTenantId is not null)
                {
                    entry.Property("TenantId").CurrentValue = CurrentTenantId;
                }


                if (CurrentBranchId is not null)
                {
                    entry.Property("BranchId").CurrentValue = CurrentBranchId;
                }


                if (entry.Entity is AuditLog || entry.State == EntityState.Detached)
                    continue;
                var auditEntry = new AuditLog(entry);

                // Update CRUD Info 
                UpdateCrudInfo(entry, auditEntry);

                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntry.UserId = GetCurrentLoogedUser();
                auditEntries.Add(auditEntry);


                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }
                    if (propertyName == "RecordSignature" && (entry.State == EntityState.Modified || entry.State == EntityState.Deleted))
                    {
                        auditEntry.RecordSignature = Guid.Parse(property.CurrentValue.ToString());
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;

                            break;

                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }

                foreach (var audit in auditEntries)
                {
                    AuditLogs.Add(audit.ToAudit());
                }


            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


        private string GetCurrentLoogedUser()
        {
            string userId = _context.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return "";
            }
            else
            {
                return userId;
            }

        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
           

            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply global query filter to all entities inheriting from BaseEntity
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
                {
                    var method = typeof(ApiContext).GetMethod(nameof(GetCombinedFilter), BindingFlags.NonPublic | BindingFlags.Instance)
                        .MakeGenericMethod(entityType.ClrType);
                    var filter = method.Invoke(this, null);
                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter((LambdaExpression)filter);
                }
            }

            // ApplyUserFilter(modelBuilder);

        }

        private LambdaExpression GetCombinedFilter<TEntity>() where TEntity : BaseEntity
        {
            var param = Expression.Parameter(typeof(TEntity), "e");

            // Tenant filter
            var tenantProp = Expression.Property(param, nameof(BaseEntity.TenantId));
            var tenantId = Expression.Property(Expression.Constant(this), nameof(ApiContext.CurrentTenantId));
            var tenantIdValue = Expression.Convert(tenantId, typeof(Guid));
            var tenantFilter = Expression.Equal(tenantProp, tenantIdValue);

            // Branch filter
            var branchProp = Expression.Property(param, nameof(BaseEntity.BranchId));
            var branchId = Expression.Property(Expression.Constant(this), nameof(ApiContext.CurrentBranchId));
            var branchIdValue = Expression.Convert(branchId, typeof(Guid?));
            var branchFilter = Expression.Equal(branchProp, branchIdValue);

            // Combine filters
            var combinedFilter = Expression.AndAlso(tenantFilter, branchFilter);

            var filter = Expression.Lambda(combinedFilter, param);
            return filter;
        }

        // Property to hold the current tenant ID
        public Guid? CurrentTenantId => ApplyTenantFilter ? _tenantProvider.GetTenantId() : Guid.Empty;

        // Property to hold the current branch ID
        public Guid? CurrentBranchId => ApplyBranchFilter ? _branchProvider.GetBranchId() : null;





    }
}
