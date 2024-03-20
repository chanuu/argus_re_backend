using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Users.DTOs
{
    public class UpdateUserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string UserName { get; set; } = default!;
        public string? PhoneNumber { get; set; }
    }
}
