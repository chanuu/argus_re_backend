using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Identity.Users.DTOs
{
    public class ChangeUserPasswordDto
    {
        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string NewPasswordConfrimed { get; set; }

        public string UserId { get; set; }
    }
}
