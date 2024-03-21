using Argus.Platform.Core.Complience.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Complience
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public async Task<IEnumerable<Document>> GetAllDocumentsAsync()
        {
            return await _documentRepository.GetAllAsync();
        }

        public async Task<Document> GetDocumentAsync(Guid documentId)
        {
            return await _documentRepository.GetAsync(documentId);
        }

        public async Task<Document> AddDocumentAsync(Document _document)
        {
            // You may perform any necessary business logic validation here 
            var document = _documentRepository.Add(_document);
            await _documentRepository.UnitOfWork.SaveChangesAsync();
            return document;
        }

        public async Task<Document> UpdateDocumentAsync(Document _document)
        {
            // You may perform any necessary business logic validation here
            var document = await _documentRepository.Update(_document);
            await _documentRepository.UnitOfWork.SaveChangesAsync();
            return document;
        }
    }
}
