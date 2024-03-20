using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Users.DTOs
{
    public class RefreshTokenResponseDto
    {
        public string AccessToken { get; set; }
        public DateTime? AccessTokenValidUntil { get; set; }
        public string ErrorMessage { get; set; }
    }
}
