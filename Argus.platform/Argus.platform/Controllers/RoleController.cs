using Argus.Platform.Application.Identity.Roles;
using Argus.Platform.Application.Identity.Roles.DTOs;
using Argus.Platform.Core.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<Role> _roleManager;

        private IRoleService _roleService { get; set; }

        public RoleController(RoleManager<Role> roleManager, IRoleService roleService)
        {
            _roleManager = roleManager;
            _roleService = roleService;
        }
        /// <summary>
        /// get all roles 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetRolesAsync();
            return Ok(roles);
        }


        [HttpGet("GetPermisionByRoleId")]
        public async Task<IActionResult> GetAll(string Id)
        {
            var roles = await _roleService.GetAllPermissionsByRoleId(Id);
            return Ok(roles);
        }



        /// <summary>
        /// create new role 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(CreateRoleDto request)
        {
            if (request.Name != null)
            {
                await _roleService.CreateRole(request);
            }
            return Ok("Add Role Sucessfully !");
        }

        /// <summary>
        /// add permsion to role
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddPermisionToRole")]
        public async Task<IActionResult> AddPermisionToRole(AddPermisonToRoleDto request)
        {
            if (request.Permision != null)
            {
                await _roleService.AddPermisionToRole(request);
            }
            return Ok("Add Permision To Role Sucessfully !");
        }

        
    }
}
