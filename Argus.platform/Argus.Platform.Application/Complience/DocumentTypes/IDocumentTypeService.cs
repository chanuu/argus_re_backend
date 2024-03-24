using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Complience.DocumentTypes
{
   public interface IDocumentTypeService : ITransientService
    {
        Task<IEnumerable<DocumentType>> GetAllDocumentTypesAsync();
        Task<DocumentType> GetDocumentTypeAsync(Guid documentTypeId);
        Task<DocumentType> AddDocumentTypeAsync(DocumentType documentType);
        Task<DocumentType> UpdateDocumentTypeAsync(DocumentType documentType);
    }
}
