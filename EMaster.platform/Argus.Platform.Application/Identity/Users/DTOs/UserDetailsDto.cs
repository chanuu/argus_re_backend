using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Users.DTOs
{
    public class UserDetailsDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string ConfirmPassword { get; set; } = default!;
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public string? AboutMe { get; set; }
        public string? RoleId { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? PartnerId { get; set; }
        public bool IsActive { get; set; }
    }
}
