using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Complience.Audits
{
    public interface IAuditService : ITransientService
    {
        Task<Audit> AddAuditAsync(Audit audit);
        Task<Audit> UpdateAuditAsync(Audit audit);
        Task<Audit> GetAuditByIdAsync(Guid id);
        Task<IEnumerable<Audit>> GetAllAuditsAsync();

        Task AddAuditRequirementAsync(Guid auditId, AuditRequirements auditRequirement);
        Task RemoveAuditRequirementAsync(Guid auditId, Guid auditRequirementId);
    }
}
