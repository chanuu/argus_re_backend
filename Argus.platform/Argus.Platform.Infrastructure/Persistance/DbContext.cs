using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Audits;
using Argus.Platform.Core.Complience.Documents;
using Argus.Platform.Core.Complience.Project;
using Argus.Platform.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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



        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
           

            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

       

    }
}
