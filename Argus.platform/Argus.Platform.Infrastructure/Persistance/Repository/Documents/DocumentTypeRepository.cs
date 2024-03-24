using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Documents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Documents
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly ApiContext _context;

        public DocumentTypeRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public DocumentType Add(DocumentType documentType)
        {
            return _context.DocumentTypes.Add(documentType).Entity;
        }

        public async Task<IEnumerable<DocumentType>> GetAllAsync()
        {
            return await _context.DocumentTypes.Include(d => d.Documents).ToListAsync();
        }

        public async Task<DocumentType> GetAsync(Guid documentTypeId)
        {
            return await _context.DocumentTypes
                                 .Include(d => d.Documents)
                                 .SingleOrDefaultAsync(dt => dt.Id == documentTypeId);
        }

        public async Task<DocumentType> GetByNameAsync(DocumentType documentType)
        {
            return await _context.DocumentTypes.Where(x => x.Name == documentType.Name).SingleOrDefaultAsync();
        }

        public async Task<DocumentType> Update(DocumentType documentType)
        {
            _context.DocumentTypes.Update(documentType);
            await _context.SaveChangesAsync();
            return documentType;
        }
    }
}
