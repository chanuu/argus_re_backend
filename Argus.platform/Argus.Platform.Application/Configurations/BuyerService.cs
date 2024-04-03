using Argus.Platform.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Configurations
{
    public class BuyerService : IBuyerService
    {
        private readonly IBuyerRepository _buyerRepository;

        public BuyerService(IBuyerRepository buyerRepository)
        {
            _buyerRepository = buyerRepository;
        }

        public async Task<Buyer> AddBuyerAsync(Buyer buyer)
        {
            return await _buyerRepository.AddAsync(buyer);
        }

        public async Task<IEnumerable<Buyer>> GetAllBuyersAsync()
        {
            return await _buyerRepository.GetAllAsync();
        }

        public async Task<Buyer> GetBuyerByIdAsync(Guid id)
        {
            return await _buyerRepository.GetByIdAsync(id);
        }

        public async Task<Buyer> UpdateBuyerAsync(Buyer buyer)
        {
            return await _buyerRepository.UpdateAsync(buyer);
        }
    }
}
