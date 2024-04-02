using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Audits
{
    public class AuditViewModel
    {
        public Guid Id { get; set; }
        public Guid BuyerId { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }

        public List<AuditRequirementsViewModel> AuditRequirements { get; set; }


    }


    public class AuditRequirementsViewModel
    {
        public Guid DocumentId { get; set; }

        public string DocumentName { get; set; }

        public string Type { get; set; }

        public DateTime? ValidUntil { get; set; }
        public RequirementStatus Status { get; set; }
        public Guid AuditId { get; set; }
    }
}
