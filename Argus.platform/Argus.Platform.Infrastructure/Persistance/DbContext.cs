using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Complience.Audits;
using Argus.Platform.Core.Complience.Documents;
using Argus.Platform.Core.Complience.Project;
using Argus.Platform.Core.Configuration;
using Argus.Platform.Core.Customers;
using Argus.Platform.Core.Identity;
using Argus.Platform.Core.Packages;
using Argus.Platform.Core.Workflows;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Argus.Platform.Infrastructure.Persistance
{
   public class ApiContext : IdentityDbContext<User, Role, string>, IUnitOfWork
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<Document> Documents { get; set; }

        public DbSet<DocumentType> DocumentTypes { get; set; }

        public DbSet<DocumentRenewal> DocumentRenewals { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectTask> ProjectTasks { get; set; }

        public DbSet<TaskComments> TaskComments { get; set; }

        public DbSet<TaskAttachment> TaskAttachment { get; set; }

        public DbSet<DocumentReview> DocumentReviews { get; set; }

        public DbSet<Audit> Audits { get; set; }

        public DbSet<AuditRequirements> AuditRequirements { get; set; }

        public DbSet<Buyer> Buyers { get; set; }

        public DbSet<AuditTrail> AuditLogs { get; set; }

        public DbSet<Company> Company { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Workflow> Workflows { get; set; }

        public DbSet<Package> Packages { get; set; }

        IHttpContextAccessor _context { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options, IHttpContextAccessor context)
            : base(options)
        {

            _context = context;
          
        }

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


            var entries = ChangeTracker.Entries().Where(E => E.State == EntityState.Added || E.State == EntityState.Modified || E.State == EntityState.Deleted).ToList();


            var auditEntries = new List<AuditLog>();
            foreach (var entry in entries)
            {


                if (entry.Entity is Audit || entry.State == EntityState.Detached)
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



       

    }
}
