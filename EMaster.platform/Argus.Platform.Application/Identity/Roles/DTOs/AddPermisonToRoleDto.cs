using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Roles.DTOs
{
    public class AddPermisonToRoleDto
    {
        public string RoleId { get; set; }

        public string Permision { get; set; }
    }
}
