using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.JobEvents
{
    public interface IJobEventRepository : IRepository<JobEvent>, ITransientService
    {
        JobEvent Add(JobEvent jobEvent);
        Task<IEnumerable<JobEvent>> GetAllAsync();
        Task<JobEvent> GetAsync(Guid jobEventId);
        Task<JobEvent> Update(JobEvent jobEvent); 
       
    }
}
