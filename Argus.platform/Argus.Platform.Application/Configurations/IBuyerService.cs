using Argus.Platform.Core.Common;
using Argus.Platform.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Configurations
{
   public interface IBuyerService : ITransientService
    {
        Task<Buyer> AddBuyerAsync(Buyer buyer);
        Task<Buyer> GetBuyerByIdAsync(Guid id);
        Task<IEnumerable<Buyer>> GetAllBuyersAsync();
        Task<Buyer> UpdateBuyerAsync(Buyer buyer);
    }
}
