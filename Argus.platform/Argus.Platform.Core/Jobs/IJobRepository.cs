using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Jobs
{
    public interface IJobRepository : IRepository<Job>, ITransientService
    {
        Job Add(Job job);

        Task<Job> Update(Job job);

        Task<Job> GetAsync(Guid jobId);

        Task<IEnumerable<Job>> GetAllAsync();

        
    }
}
