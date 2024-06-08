using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Jobs
{
    public interface IJobTypeRepository : IRepository<JobType>, ITransientService
    {
        JobType Add(JobType jobType);

        Task<JobType> Update(JobType jobType);

        Task<JobType> GetAsync(Guid jobTypeId);

        Task<IEnumerable<JobType>> GetAllAsync();
    }
}
