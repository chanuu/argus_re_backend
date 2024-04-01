using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Audits;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Audits
{
    public class AuditRepository : IAuditRepository
    {
        private readonly ApiContext _context;

        public AuditRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public async Task<Audit> AddAsync(Audit audit)
        {
            await _context.Audits.AddAsync(audit);
            await _context.SaveChangesAsync();
            return audit;
        }

        public async Task<IEnumerable<Audit>> GetAllAsync()
        {
            return await _context.Audits.Include(a => a.AuditRequirements).ToListAsync();
        }

        public async Task<Audit> GetByIdAsync(Guid id)
        {
            return await _context.Audits
                .Include(a => a.AuditRequirements)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Audit> UpdateAsync(Audit audit)
        {
            _context.Audits.Update(audit);
            await _context.SaveChangesAsync();
            return audit;
        }


        public async Task AddAuditRequirementAsync(Guid auditId, AuditRequirements auditRequirement)
        {
            var audit = await _context.Audits.Include(a => a.AuditRequirements)
                                .FirstOrDefaultAsync(a => a.Id == auditId);
            if (audit != null)
            {
                audit.AuditRequirements.Add(auditRequirement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAuditRequirementAsync(Guid auditId, Guid auditRequirementId)
        {
            var auditRequirement = await _context.AuditRequirements
                                    .FirstOrDefaultAsync(ar => ar.AuditId == auditId && ar.Id == auditRequirementId);
            if (auditRequirement != null)
            {
                _context.AuditRequirements.Remove(auditRequirement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
