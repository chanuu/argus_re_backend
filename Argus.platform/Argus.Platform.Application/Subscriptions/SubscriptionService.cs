using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Subscriptions
{
   public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionReposirory;
        public SubscriptionService(ISubscriptionRepository subscriptionReposirory)
        {
            _subscriptionReposirory = subscriptionReposirory;
        }

        public async Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync()
        {
            return await _subscriptionReposirory.GetAllAsync();
        }


        public async Task<Subscription> GetSubscriptionAsync(Guid subscriptionId)
        {
            return await _subscriptionReposirory.GetAsync(subscriptionId);
        }

        public async Task<Subscription> AddSubscriptionAsync(Subscription subscription)
        {
            // You may perform any necessary business logic validation here 
            var _subscriptions = _subscriptionReposirory.Add(subscription);
            await _subscriptionReposirory.UnitOfWork.SaveChangesAsync();
            return _subscriptions;
        }

        public async Task<Subscription> UpdateSubscriptionAsync(Subscription subscription)
        {

            var _subscription = await _subscriptionReposirory.Update(subscription);
            await _subscriptionReposirory.UnitOfWork.SaveChangesAsync();
            return _subscription;
        }

    }
}
