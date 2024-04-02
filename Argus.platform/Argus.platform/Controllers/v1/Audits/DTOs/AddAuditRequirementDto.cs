using Argus.Platform.Core.Complience.Audits;
using System.ComponentModel.DataAnnotations.Schema;

namespace Argus.Platform.Controllers.v1.Audits.DTOs
{
    public class AddAuditRequirementInputDto
    {
      
        public Guid DocumentId { get; set; }

        public RequirementStatus Status { get; set; }

        public Guid AuditId { get; set; }
    }
}
