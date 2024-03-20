using Argus.Platform.Core.Common;
using Argus.Platform.Core.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance
{
   public class ApiContext : IdentityDbContext<User, Role, string>, IUnitOfWork
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }
        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
           

            var result = await base.SaveChangesAsync(cancellationToken);

            return true;
        }

       

    }
}
