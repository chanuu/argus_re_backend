using Argus.Platform.Core.Common;
using Argus.Platform.Core.Features;
using Argus.Platform.Core.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Subscriptions
{
    public class Subscription : BaseEntity
    {
        
        public string Name { get; set; }      
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Feature> Features { get; set; }
    }
}



