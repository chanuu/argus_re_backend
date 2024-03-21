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
        Document Add(Document order);

        Task<Document> Update(Document order);

        Task<Document> GetAsync(Guid orderId);

        Task<IEnumerable<Document>> GetAllAsync();
    }
}
