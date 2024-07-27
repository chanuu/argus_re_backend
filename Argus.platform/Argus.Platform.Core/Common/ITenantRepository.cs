using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Common
{
    public interface ITenantRepository : ITransientService, IRepository<Tenants>
    {
        Task<Tenants> AddAsync(Tenants tenant, User user, Branch branch, Company company);

        Task<Tenants> Update(Tenants tenant);

        Task<Tenants> GetAsync(Guid tenantId);

        Task<IEnumerable<Tenants>> GetAllAsync();
    }
}
