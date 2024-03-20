using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Users.DTOs
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenValidUntil { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenValidUntil { get; set; }
        public UserDetailsDto User { get; set; }
        public string? UserId { get; set; }
        public string? RoleId { get; set; }
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? PartnerId { get; set; }
        public bool IsActive { get; set; }
    }
}
