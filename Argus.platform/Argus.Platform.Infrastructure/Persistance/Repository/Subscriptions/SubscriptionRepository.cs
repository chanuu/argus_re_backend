using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Subscriptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Subscriptions
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApiContext _context;

        public SubscriptionRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Subscription Add(Subscription subscription)
        {
            return _context.Subscriptions.Add(subscription).Entity;
        }


        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _context.Subscriptions.ToListAsync();
        }

        public async Task<Subscription> GetAsync(Guid subscriptionId)
        {
            return await _context.Subscriptions.SingleOrDefaultAsync();
        }

        public async Task<Subscription> Update(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);

            await _context.SaveChangesAsync();

            return subscription;
        }
    }
}
