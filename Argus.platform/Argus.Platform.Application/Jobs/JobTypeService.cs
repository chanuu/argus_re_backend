using Argus.Platform.Core.Complience.Documents;
using Argus.Platform.Core.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Jobs
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IJobTypeRepository _jobTypeRepository;          

        public JobTypeService(IJobTypeRepository jobTypeRepository)
        {
           _jobTypeRepository = jobTypeRepository;
        }

        public async Task<IEnumerable<JobType>> GetAllJobTypesAsync()
        {
            return await _jobTypeRepository.GetAllAsync();
        }

        public async Task<JobType> GetJobTypeAsync(Guid jobTypeId)
        {
            return await _jobTypeRepository.GetAsync(jobTypeId);
        }

        public async Task<JobType> AddJobTypeAsync(JobType jobType)
        {                       
                var addedJobType = _jobTypeRepository.Add(jobType);
                await _jobTypeRepository.UnitOfWork.SaveChangesAsync();  
                return addedJobType;
           
        }

        public async Task<JobType> UpdateJobTypeAsync(JobType jobType)
        {
           
            var updatedJobType = await _jobTypeRepository.Update(jobType);
            await _jobTypeRepository.UnitOfWork.SaveChangesAsync();
            return updatedJobType;
        }
              
    }
}
