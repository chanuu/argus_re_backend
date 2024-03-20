using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Roles.DTOs
{
    public class RolePermisionDto
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string NormalizeName { get; set; }

        public List<Claim> Permisions { get; set; }
    }
}
