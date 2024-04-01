using Argus.Platform.Core.Common;
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
        public Guid DocumentId { get; set; }

        public RequirementStatus Status { get; set; }

        [ForeignKey("DocumentId")]
        public Audit Audit { get; set; }

        public Guid AuditId { get; set; }
    }


    public enum RequirementStatus
    {
        Compulsory,
        Optional
    }
}
