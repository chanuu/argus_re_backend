using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Complience.Documents
{
    public interface IDocumentRepository : IRepository<Document>, ITransientService
    {
        Document Add(Document document);

        Task<Document> Update(Document document);

        Task<Document> GetAsync(Guid documentId);

        Task<IEnumerable<Document>> GetAllAsync();

        Task<Document> AddRenewalAsync(DocumentRenewal document);
    }
}
