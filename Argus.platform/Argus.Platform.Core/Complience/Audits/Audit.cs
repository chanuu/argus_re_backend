using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Audits
{
  
    public class Audit : BaseEntity
    {

        public Guid BuyerId { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }
        public List<AuditRequirements> AuditRequirements { get; set; }
    }
   
}
