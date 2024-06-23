using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.JobEvents
{
    public class JobEvent : BaseEntity
    {
        public Guid TenantId { get; set; }
        public string StartingTime { get; set; }
        public string EndTime { get; set; }
        public string Name { get; set; }
        public string Lcation { get; set; }
        public bool IsAlreadyEvent { get; set; }
        public bool IsMainEvent { get; set; }
        public DateOnly Date {  get; set; }

        public static JobEvent Create(string startingTime, string name, Guid tenantId, string endTime, string Lcation, bool isAlreadyEvent, bool isMainEvent, DateOnly date)
        {
            JobEvent jobEvent = new JobEvent()
            {
                TenantId = tenantId,
                Name = name,
                StartingTime = startingTime,
                EndTime = endTime,
                Lcation = Lcation,  
                IsAlreadyEvent = isAlreadyEvent,    
                IsMainEvent = isMainEvent,
                Date = date
              
            };

            return jobEvent;

        }
    }
}
