using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Identity;
using Argus.Platform.Core.Packages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.WorkItems
{
    public class WorkItem : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string Event { get; set; }
        public int OffSset { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; }

        public static WorkItem Create(Guid tenantId, string Event, int offSset, string userId)
        {
            WorkItem workItem = new WorkItem()
            {
                TenantId = tenantId,
                Event = Event,
                OffSset = offSset,
                UserId = userId
            };

            return workItem;

        }

    }
}