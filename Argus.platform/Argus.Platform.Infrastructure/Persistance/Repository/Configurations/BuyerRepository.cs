using Argus.Platform.Core.Common;
using Argus.Platform.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Configurations
{
    public class BuyerRepository : IBuyerRepository
    {

        private readonly ApiContext _context;

        public BuyerRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }
        public async Task<Buyer> AddAsync(Buyer buyer)
        {
            await _context.Buyers.AddAsync(buyer);
            await _context.SaveChangesAsync();
            return buyer;
        }

        public async Task<IEnumerable<Buyer>> GetAllAsync()
        {
            return await _context.Buyers.ToListAsync();
        }

        public async Task<Buyer> GetByIdAsync(Guid id)
        {
            return await _context.Buyers.FindAsync(id);
        }

        public async Task<Buyer> UpdateAsync(Buyer buyer)
        {
            _context.Buyers.Update(buyer);
            await _context.SaveChangesAsync();
            return buyer;
        }
    }
}
