using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Configuration
{
    public interface IBuyerRepository : IRepository<Buyer>, ITransientService
    {
        Task<Buyer> AddAsync(Buyer buyer);
        Task<Buyer> UpdateAsync(Buyer buyer);
        Task<Buyer> GetByIdAsync(Guid id);
        Task<IEnumerable<Buyer>> GetAllAsync();
    }
}
