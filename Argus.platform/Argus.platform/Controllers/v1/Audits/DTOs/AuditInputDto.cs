using Argus.Platform.Core.Complience.Audits;
using System.ComponentModel.DataAnnotations.Schema;

namespace Argus.Platform.Controllers.v1.Audits.DTOs
{
    public class AuditInputDto
    {
        public Guid BuyerId { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }
        public List<AuditRequirementsDto> AuditRequirements { get; set; }
    }


    public class AuditRequirementsDto
    {
        public Guid DocumentId { get; set; }

        public RequirementStatus Status { get; set; }
        public Guid AuditId { get; set; }
    }
}
