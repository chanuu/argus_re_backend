using Argus.Platform.Core.Common;
using Argus.Platform.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Companies
{
    public class UserBranch : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }


        public Branch Branch { get; set; }
    }
}
