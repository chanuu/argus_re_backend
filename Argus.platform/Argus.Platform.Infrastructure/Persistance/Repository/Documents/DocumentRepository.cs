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
            document.DocumentRenewal = new List<DocumentRenewal>();
            document.DocumentRenewal.Add(new DocumentRenewal {Id = Guid.NewGuid(), FromDate = DateTime.UtcNow.Date, ExpireDate = DateTime.UtcNow.AddMonths(document.ValidPeriod),ScanCopy= "",Status = DocumentStatus.Valid });
            return _context.Documents.Add(document).Entity;
        }

        public async Task<Document> AddRenewalAsync(DocumentRenewal document)
        {
            var documents = await _context
                .Documents.Include(x=>x.DocumentRenewal)
                .Where(x => x.Id == document.DocumentId)
                .SingleOrDefaultAsync();
            if(documents is null)
            {
                throw new Exception("No document with given Id");
            }
            document.DocumentId = documents.Id;
            _context.DocumentRenewals.Add(document);
            
            
            await _context.SaveChangesAsync();
            return documents;
        }

        public async Task<IEnumerable<Document>> GetAllAsync()
        {
            return  await _context.Documents.Include(x => x.DocumentTypes).ToListAsync();
            
        }

        public async Task<Document> GetAsync(Guid Id)
        {
            return await _context.Documents.
                Include(x=>x.DocumentRenewal)
                .Where(x=>x.Id == Id)
                .SingleOrDefaultAsync();
        }

        public async Task<Document> Update(Document document)
        {
           
            _context.Documents.Update(document);

            await _context.SaveChangesAsync();

            return document;
        }

       
    }
}
