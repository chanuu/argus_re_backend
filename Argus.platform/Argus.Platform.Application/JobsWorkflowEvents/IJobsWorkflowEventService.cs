using Argus.Platform.Core.Common;
using Argus.Platform.Core.JobsWorkflowEvents;
using Argus.Platform.Core.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.JobsWorkflowEvents
{
    public interface IJobsWorkflowEventService : ITransientService
    {
        Task<IEnumerable<JobsWorkflowEvent>> GetAllJobsWorkflowEventsAsync();
        Task<JobsWorkflowEvent> GetJobsWorkflowEventAsync(Guid jobsWorkflowEventId);
        Task<JobsWorkflowEvent> AddJobsWorkflowEventAsync(JobsWorkflowEvent _jobsWorkflowEvent);
        Task<JobsWorkflowEvent> UpdateJobsWorkflowEventAsync(JobsWorkflowEvent _jobsWorkflowEvent);
    }
}
