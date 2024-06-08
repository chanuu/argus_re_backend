using Argus.Platform.Core.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Jobs
{
    public interface IJobTypeService
    {
        Task<IEnumerable<JobType>> GetAllJobTypesAsync();
        Task<JobType> GetJobTypeAsync(Guid jobTypeId);
        Task<JobType> AddJobTypeAsync(JobType jobType);
        Task<JobType> UpdateJobTypeAsync(JobType jobType);
    }
}
