using Argus.Platform.Core.Complience.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Complience.DocumentTypes
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<IEnumerable<DocumentType>> GetAllDocumentTypesAsync()
        {
            return await _documentTypeRepository.GetAllAsync();
        }

        public async Task<DocumentType> GetDocumentTypeAsync(Guid documentTypeId)
        {
            return await _documentTypeRepository.GetAsync(documentTypeId);
        }

        public async Task<DocumentType> AddDocumentTypeAsync(DocumentType documentType)
        {
            // Validation logic can be added here
            if(ValidateDocumentType(documentType) == true)
            {
                var addedDocumentType = _documentTypeRepository.Add(documentType);
                await _documentTypeRepository.UnitOfWork.SaveChangesAsync();
                return addedDocumentType;
            }
            else
            {
                throw new Exception("Your Input Values and Not Valid");
            }
            
        }

        public async Task<DocumentType> UpdateDocumentTypeAsync(DocumentType documentType)
        {
            // Validation logic can be added here
            var updatedDocumentType = await _documentTypeRepository.Update(documentType);
            await _documentTypeRepository.UnitOfWork.SaveChangesAsync();
            return updatedDocumentType;
        }

        private bool ValidateDocumentType(DocumentType documentType)
        {
            if(documentType == null)
            {
                throw new Exception("Document Type Cannot Be Null");
            }
            else if(IsAlreadyExist(documentType) == true)
            {
                throw new Exception("Document Type Is Alredy Exist !");
            }
            else
            {
                return true;
            }
        }

        private bool IsAlreadyExist(DocumentType _documentType)
        {
            var documentType = _documentTypeRepository.GetByNameAsync(_documentType);
            if (documentType == null)
            {
                return false;
            }
            else { return true; }

        }
    }
}
