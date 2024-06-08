using Argus.Platform.Core.JobsWorkflowEvents;
using Argus.Platform.Core.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.JobsWorkflowEvents
{
    internal class JobsWorkflowEventService : IJobsWorkflowEventService
    {
        private readonly IJobsWorkflowEventRepository _jobsWorkflowEventRepository;
        public JobsWorkflowEventService(IJobsWorkflowEventRepository jobsWorkflowEventRepository)
        {
            _jobsWorkflowEventRepository = jobsWorkflowEventRepository;
        }

        public async Task<IEnumerable<JobsWorkflowEvent>> GetAllJobsWorkflowEventsAsync()
        {
            return await _jobsWorkflowEventRepository.GetAllAsync();
        }


        public async Task<JobsWorkflowEvent> GetJobsWorkflowEventAsync(Guid jobsWorkflowEventId)
        {
            return await _jobsWorkflowEventRepository.GetAsync(jobsWorkflowEventId);
        }

        public async Task<JobsWorkflowEvent> AddJobsWorkflowEventAsync(JobsWorkflowEvent _jobsWorkflowEvent)
        {
            var jobsWorkflowEvent = _jobsWorkflowEventRepository.Add(_jobsWorkflowEvent);
            await _jobsWorkflowEventRepository.UnitOfWork.SaveChangesAsync();
            return jobsWorkflowEvent;
        }

        public async Task<JobsWorkflowEvent> UpdateJobsWorkflowEventAsync(JobsWorkflowEvent _jobsWorkflowEvent)
        {

            var jobsWorkflowEvent = await _jobsWorkflowEventRepository.Update(_jobsWorkflowEvent);
            await _jobsWorkflowEventRepository.UnitOfWork.SaveChangesAsync();
            return jobsWorkflowEvent;
        }

       
    }
}
