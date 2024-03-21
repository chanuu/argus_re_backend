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
    public class DocumentRepository :IDocumentRepository
    {
        private readonly ApiContext _context;

        public DocumentRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Document Add(Document document)
        {
            return _context.Documents.Add(document).Entity;
        }


        public async Task<IEnumerable<Document>> GetAllAsync()
        {
            return await _context.Documents.ToListAsync();
        }

        public async Task<Document> GetAsync(Guid orderId)
        {
            return await _context.Documents.SingleOrDefaultAsync();
        }

        public async Task<Document> Update(Document document)
        {
            _context.Documents.Update(document);

            await _context.SaveChangesAsync();

            return document;
        }
    }
}
