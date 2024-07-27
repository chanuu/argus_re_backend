using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Common
{
    public interface ITenantService : ITransientService
    {
        Task<IEnumerable<Tenants>> GetAllTenants();
        Task<Tenants> GetTenantAsync(Guid tenantsId);
        Task<Tenants> AddTenantAsync(Tenants tenant, User user, Branch branch, Company company);
        Task<Tenants> UpdateTenantAsync(Tenants tenants);
    }
}
