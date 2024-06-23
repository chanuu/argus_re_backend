using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Documents;
using Argus.Platform.Core.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Jobs
{
    public interface IJobService : ITransientService
    {
        Task<IEnumerable<Job>> GetAllJobsAsync();
        Task<Job> GetJobAsync(Guid jobId);
        Task<Job> AddJobAsync(Job job);
        Task<Job> UpdateJobAsync(Job job);

       
    }
}
