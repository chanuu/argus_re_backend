using Argus.Platform.Application.Identity.Roles.DTOs;
using Argus.Platform.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Roles
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> _RoleManager;

        public RoleService(RoleManager<Role> roleManager)
        {
            _RoleManager = roleManager;
        }


        public async Task AddPermisionToRole(AddPermisonToRoleDto request)
        {
            var role = _RoleManager.FindByIdAsync(request.RoleId);
            if (role == null)
            {
                return;
            }
            var allClaims = await _RoleManager.GetClaimsAsync(role.Result);

            if (!allClaims.Any(a => a.Type == "Permission" && a.Value == request.Permision))
            {
                await _RoleManager.AddClaimAsync(role.Result, new Claim("Permission", request.Permision));
            }
        }

        public async Task CreateRole(CreateRoleDto request)
        {
            await _RoleManager.CreateAsync(new Role(request.Name.Trim()));
        }

        public async Task<RolePermisionDto> GetAllPermissionsByRoleId(string RoleId)
        {
            var role = await _RoleManager.FindByIdAsync(RoleId);

            var allClaims = await _RoleManager.GetClaimsAsync(role);
            //todo: need to implement autipammer here 
            RolePermisionDto dto = new RolePermisionDto();
            dto.Name = role.Name;
            dto.Permisions = allClaims.ToList();

            return dto;
        }

        public async Task<List<Role>> GetRolesAsync()
        {
            var roles = await _RoleManager.Roles.ToListAsync();

            return roles;
        }

        public async Task<bool> GrantAllPermisionAsync(string RoleId)
        { // check is role is available 
            var role = await _RoleManager.FindByIdAsync(RoleId);

            if (role is null)
            {
                return false;
            }
            var allClaims = await _RoleManager.GetClaimsAsync(role);
            // get all permision 
            //var Permsions = List<Permision>;

            //foreach (var permission in Permsions)
            //{
            //    if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission.Permision))
            //    {
            //        await _roleManager.AddClaimAsync(role, new Claim("Permission", permission.Permision));
            //    }
            //}
            return true; throw new NotImplementedException();
        }
    }
}
