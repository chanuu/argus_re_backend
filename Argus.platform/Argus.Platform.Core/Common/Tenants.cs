using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Common
{
    public class Tenants : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public string Email { get; set; }

        public string ConnetionString { get; set; }
    }
}
