using Argus.Platform.Application.Complience.Audits;
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
            return await _context.Audits
                .Include(a => a.AuditRequirements)
                  .ThenInclude(ar => ar.Document)

                .ToListAsync();


        }
        public async Task<AuditViewModel> GetByIdAsync(Guid id)
        {
            // Fetch the audit and related data
            var audit = await _context.Audits
                 .Include(a => a.AuditRequirements)
                     .ThenInclude(ar => ar.Document)
                         .ThenInclude(d => d.DocumentRenewal) // Include DocumentRenewal
                 .Include(a => a.AuditRequirements) // You need to repeat the Include for AuditRequirements
                     .ThenInclude(ar => ar.Document)
                         .ThenInclude(d => d.DocumentTypes) // Then include DocumentType
                 .AsNoTracking()
                 .FirstOrDefaultAsync(a => a.Id == id);

            // Check if the audit exists
            if (audit == null) return null;

            // Manually project the audit to the AuditViewModel
            var auditViewModel = new AuditViewModel
            {
                Id = audit.Id,
                BuyerId = audit.BuyerId,
                Name = audit.Name,
                Frequency = audit.Frequency,
                AuditRequirements = audit.AuditRequirements.Select(ar => new AuditRequirementsViewModel
                {
                    DocumentId = ar.DocumentId,
                    DocumentName = ar.Document.Name,
                    Type = ar.Document.DocumentTypes.Name, 
                    ValidUntil = ar.Document.DocumentRenewal.LastOrDefault()?.ExpireDate, 
                    Status = ar.Status,
                    AuditId = audit.Id
                }).ToList()
            };

            return auditViewModel;
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
