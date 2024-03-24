using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Documents
{
    public interface IDocumentTypeRepository : IRepository<DocumentType>, ITransientService
    {
        DocumentType Add(DocumentType documentType);
        Task<DocumentType> Update(DocumentType documentType);
        Task<DocumentType> GetAsync(Guid documentTypeId);

        Task<DocumentType> GetByNameAsync(DocumentType documentType);
        Task<IEnumerable<DocumentType>> GetAllAsync();
    }
}
