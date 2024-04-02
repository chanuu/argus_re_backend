using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Documents;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Audits
{
    public class AuditRequirements : BaseEntity
    {
        [ForeignKey("DocumentId")]
        public Guid DocumentId { get; set; }

        public Document Document { get; set; }

        public RequirementStatus Status { get; set; }

        [ForeignKey("AuditId")]
        public Audit Audit { get; set; }

        public Guid AuditId { get; set; }
    }


    public enum RequirementStatus
    {
        Compulsory,
        Optional
    }
}
