using Argus.Platform.Core.Common;
using Argus.Platform.Core.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.JobsWorkflowEvents
{
    public interface IJobsWorkflowEventRepository : IRepository<JobsWorkflowEvent>, ITransientService
    {
        JobsWorkflowEvent Add(JobsWorkflowEvent jobsWorkflowEvent);
        Task<IEnumerable<JobsWorkflowEvent>> GetAllAsync();
        Task<JobsWorkflowEvent> GetAsync(Guid jobsWorkflowEventId);
        Task<JobsWorkflowEvent> Update(JobsWorkflowEvent jobsWorkflowEvent);

    }
}
