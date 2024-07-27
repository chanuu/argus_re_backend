using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Subscriptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Features
{
    public class Feature : BaseEntity
    {
        public string FeatureName { get; set; }
        public string Limit { get; set; }
        public string DiscriminatorMessage { get; set; }

        [ForeignKey("SubscriptionId")]
        public Guid SubscriptionId { get; set; }
        public Subscription Subscriptions { get; set; }

    }
}
