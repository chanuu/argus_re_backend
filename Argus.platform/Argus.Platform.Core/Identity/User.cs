using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Identity
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }

        public string? ObjectId { get; set; }

        public DateTime? CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public int? CreatedBy { get; set; }

        public int? DeletedBy { get; set; }

        public int LastUpdatedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
