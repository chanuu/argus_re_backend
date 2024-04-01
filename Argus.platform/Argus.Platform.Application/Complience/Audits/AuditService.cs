using Argus.Platform.Core.Complience.Audits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Complience.Audits
{
    public class AuditService : IAuditService
    {
        private readonly IAuditRepository _auditRepository;

        public AuditService(IAuditRepository auditRepository)
        {
            _auditRepository = auditRepository;
        }

        public async Task<Audit> AddAuditAsync(Audit audit)
        {
            return await _auditRepository.AddAsync(audit);
        }

        public async Task<IEnumerable<Audit>> GetAllAuditsAsync()
        {
            return await _auditRepository.GetAllAsync();
        }

        public async Task<Audit> GetAuditByIdAsync(Guid id)
        {
            return await _auditRepository.GetByIdAsync(id);
        }

        public async Task<Audit> UpdateAuditAsync(Audit audit)
        {
            return await _auditRepository.UpdateAsync(audit);
        }


        public async Task AddAuditRequirementAsync(Guid auditId, AuditRequirements auditRequirement)
        {
            await _auditRepository.AddAuditRequirementAsync(auditId, auditRequirement);
        }

        public async Task RemoveAuditRequirementAsync(Guid auditId, Guid auditRequirementId)
        {
            await _auditRepository.RemoveAuditRequirementAsync(auditId, auditRequirementId);
        }
    }
}
