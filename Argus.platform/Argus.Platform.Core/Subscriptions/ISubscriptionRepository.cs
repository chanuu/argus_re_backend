using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Subscriptions
{
    public interface ISubscriptionRepository : IRepository<Subscription>, IScopedService
    {
        Subscription Add(Subscription subscription);
        Task<IEnumerable<Subscription>> GetAllAsync();
        Task<Subscription> GetAsync(Guid subscriptionId);
        Task<Subscription> Update(Subscription subscription);
    }
}
