using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Subscriptions
{
  public interface ISubscriptionService : ITransientService
    {
        Task<IEnumerable<Subscription>> GetAllSubscriptionsAsync();
        Task<Subscription> GetSubscriptionAsync(Guid subscriptionId);
        Task<Subscription> AddSubscriptionAsync(Subscription subscription);
        Task<Subscription> UpdateSubscriptionAsync(Subscription subscription);
    }
}
