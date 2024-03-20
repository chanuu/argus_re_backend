using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Users.DTOs
{
    public class AddToRoleDto
    {
        public List<string> Role { get; set; }

        public string UserId { get; set; }
    }
}
