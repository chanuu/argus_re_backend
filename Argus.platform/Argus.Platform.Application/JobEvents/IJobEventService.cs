using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using Argus.Platform.Core.JobEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.JobEvents
{
    public interface IJobEventService : ITransientService
    {
        Task<IEnumerable<JobEvent>> GetAllJobEventsAsync();
        Task<JobEvent> GetJobEventAsync(Guid jobEventId);
        Task<JobEvent> AddJobEventAsync(JobEvent _jobEvent);
        Task<JobEvent> UpdateJobEventAsync(JobEvent _jobEvent);
    }
}
