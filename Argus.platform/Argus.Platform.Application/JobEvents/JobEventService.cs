using Argus.Platform.Core.Customers;
using Argus.Platform.Core.JobEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.JobEvents
{
    public class JobEventService : IJobEventService
    {
        private readonly IJobEventRepository _jobEventRepository;
        public JobEventService(IJobEventRepository jobEventRepository)
        {
           _jobEventRepository = jobEventRepository;
        }

        public async Task<IEnumerable<JobEvent>> GetAllJobEventsAsync()
        {
            return await _jobEventRepository.GetAllAsync();
        }


        public async Task<JobEvent> GetJobEventAsync(Guid jobEventId)
        {
            return await _jobEventRepository.GetAsync(jobEventId);
        }

        public async Task<JobEvent> AddJobEventAsync(JobEvent _jobEvent)
        {
            var customer = _jobEventRepository.Add(_jobEvent);
            await _jobEventRepository.UnitOfWork.SaveChangesAsync();
            return customer;
        }

     
        public  async Task<JobEvent> UpdateJobEventAsync(JobEvent _jobEvent)
        {
            var jobEvent = await _jobEventRepository.Update(_jobEvent);
            await _jobEventRepository.UnitOfWork.SaveChangesAsync();
            return jobEvent;
        }
    }
}
