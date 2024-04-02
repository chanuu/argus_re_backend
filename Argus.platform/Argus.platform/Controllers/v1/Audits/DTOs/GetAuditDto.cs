using Argus.Platform.Controllers.v1.Documents.DTOs;
using Argus.Platform.Core.Complience.Audits;

namespace Argus.Platform.Controllers.v1.Audits.DTOs
{
    public class GetAuditDto
    {
        public Guid BuyerId { get; set; }
        public string Name { get; set; }
        public int Frequency { get; set; }

        public List<AuditRequirementsDetailDto> AuditRequirements { get; set; }
    }

    public class AuditRequirementsDetailDto
    {
        public Guid DocumentId { get; set; }

        public string DocumentName { get; set; }

        public string Type { get; set; }

        public DateTime? ValidUntil { get; set; }
        public RequirementStatus Status { get; set; }
        public Guid AuditId { get; set; }
    }

   


}
