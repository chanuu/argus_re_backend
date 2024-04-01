using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Audits
{
    public interface IAuditRepository : ITransientService
    {
        Task<Audit> AddAsync(Audit audit);
        Task<Audit> UpdateAsync(Audit audit);
        Task<Audit> GetByIdAsync(Guid id);
        Task<IEnumerable<Audit>> GetAllAsync();

        Task AddAuditRequirementAsync(Guid auditId, AuditRequirements auditRequirement);
        Task RemoveAuditRequirementAsync(Guid auditId, Guid auditRequirementId);
    }
}
