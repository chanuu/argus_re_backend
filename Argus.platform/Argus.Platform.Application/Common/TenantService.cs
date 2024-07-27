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
    public class TenantService : ITenantService
    {
        private readonly ITenantRepository _TenantRepository;

        public TenantService(ITenantRepository tenantRepository)
        {
            _TenantRepository = tenantRepository;
        }

        public async Task<Tenants> AddTenantAsync(Tenants tenant, User user, Branch branch, Company company)
        {
            var _tenant = await _TenantRepository.AddAsync(tenant,user,branch,company);
            await _TenantRepository.UnitOfWork.SaveChangesAsync();
            return _tenant;
        }

        public Task<IEnumerable<Tenants>> GetAllTenants()
        {
            throw new NotImplementedException();
        }

        public Task<Tenants> GetTenantAsync(Guid tenantsId)
        {
            throw new NotImplementedException();
        }

        public Task<Tenants> UpdateTenantAsync(Tenants tenants)
        {
            throw new NotImplementedException();
        }
    }
}
