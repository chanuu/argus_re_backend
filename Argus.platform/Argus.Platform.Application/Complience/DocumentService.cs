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
            if (!ValidateDocument(_document))
            {
                throw new Exception("Please Complete Required Fields");
            }
            else
            {
                var document = _documentRepository.Add(_document);
                await _documentRepository.UnitOfWork.SaveChangesAsync();
                return document;
            }

        }

        public async Task<Document> UpdateDocumentAsync(Document _document)
        {
           
            if (!ValidateDocument(_document))
            {
                throw new Exception("Please Complete Required Fields");
            }
            else
            {
                var document = await _documentRepository.Update(_document);
                await _documentRepository.UnitOfWork.SaveChangesAsync();
                return document;
            }

        }


        private bool ValidateDocument(Document document)
        {
            switch (document)
            {
                case { Code: null }:
                    throw new Exception("Document Code cannot be null");
                case { AccessLevel: null or "" }:
                    throw new Exception("Document Access Level cannot be null or empty");
                case { AlertBefore: <= 0 }:
                    throw new Exception("Alert Before cannot be Zero or Negative");
                default:
                    return true;
            }
        }

    }
}
