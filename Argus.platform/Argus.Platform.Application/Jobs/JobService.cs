using Argus.Platform.Core.Complience.Documents;
using Argus.Platform.Core.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Jobs
{
    public class JobService : IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _jobRepository.GetAllAsync();
        }

        public async Task<Job> GetJobAsync(Guid jobId)
        {
            return await _jobRepository.GetAsync(jobId);
        }

        public async Task<Job> AddJobAsync(Job _job)
        {                       
             var job = _jobRepository.Add(_job);
             await _jobRepository.UnitOfWork.SaveChangesAsync();
             return job;           
        }

        public async Task<Job> UpdateJobAsync(Job _job)
        {
           
             var job = await _jobRepository.Update(_job);
             await _jobRepository.UnitOfWork.SaveChangesAsync();
             return job;            

        }
    }
}
