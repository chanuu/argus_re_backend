using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Roles.DTOs
{
    public class CreateRoleDto
    {
        [Required]
        public string Name { get; set; }
    }
}
