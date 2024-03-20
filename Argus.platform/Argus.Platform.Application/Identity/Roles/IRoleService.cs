using Argus.Platform.Application.Identity.Roles.DTOs;
using Argus.Platform.Core.Common;
using Argus.Platform.Core.Identity;


namespace Argus.Platform.Application.Identity.Roles
{
    public interface IRoleService:ITransientService
    {
        Task<RolePermisionDto> GetAllPermissionsByRoleId(string RoleId);

        Task<List<Role>> GetRolesAsync();

        Task CreateRole(CreateRoleDto request);

        Task AddPermisionToRole(AddPermisonToRoleDto request);

        Task<bool> GrantAllPermisionAsync(string RoleId);
    }
}
