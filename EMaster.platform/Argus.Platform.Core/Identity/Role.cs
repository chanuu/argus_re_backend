using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Identity
{
    public class Role : IdentityRole
    {
        public string? Description { get; set; }
        public DateTime? CreationTime { get; set; }

        public DateTime? DeletionTime { get; set; }

        public DateTime? LastModifiedOn { get; set; }

        public int? CreatedBy { get; set; }

        public int? DeletedBy { get; set; }

        public int LastUpdatedBy { get; set; }

        public bool IsDeleted { get; set; }

        public Role(string name, string? description = null)
            : base(name)
        {
            Description = description;
            NormalizedName = name.ToUpperInvariant();
        }

        public Role() { }


        public static Role Create(string? _name, string _normalizedName, string? _decription)
        {
            var Role = new Role
            {
                Name = _name,
                Description = _decription,
                NormalizedName = _normalizedName
            };
            return Role;
        }
    }
}
