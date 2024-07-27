using Argus.Platform.Application.Common;
using Argus.Platform.Application.Identity.Users.DTOs;
using Argus.Platform.Application.Identity.Users;
using Argus.Platform.Contract.V1;
using Microsoft.AspNetCore.Mvc;

using Mapster;
using Argus.Platform.Controllers.v1.Tenant.DTOs;
using Argus.Platform.Core.Common;
using Argus.Platform.Core.Identity;
using Argus.Platform.Controllers.v1.Branches;
using Argus.Platform.Core.Companies;

namespace Argus.Platform.Controllers.v1.Tenant
{
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpPost(ApiRoutes.Tenant.Create)]
        public async Task<IActionResult> AddTenant(TenantCreateInputDto tenantDto)
        {

            var tenant = tenantDto.Adapt<Tenants>();
            tenant.TenantId = Guid.NewGuid();

            var user = new User();
            user.UserName = tenantDto.UserName;
            user.Email = tenantDto.AdminEmailAddress;
            user.PasswordHash = tenantDto.AdminPassword;

            Branch branch = new Branch();
            branch.BranchId = Guid.NewGuid();
            branch.Name= tenantDto.BrachName;
            branch.Email = tenantDto.BrachEmail;
            branch.ContactNo = "";
            branch.Address = "";

            Company company = new Company();
            company.Name = tenantDto.CompanyName;
            company.Email = tenantDto.CompanyEmail;
            company.LogoUrl = "";
            company.ContactNo = "";

           var createdTenant = await  _tenantService.AddTenantAsync(tenant,user,branch,company);


            return Ok(Response);
        }
    }
}
