using Argus.Platform.Core.Common;
using Argus.Platform.Core.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.WorkItems
{
    public interface IWorkItemRepsitory : IRepository<WorkItem>, ITransientService
    {
        WorkItem Add(WorkItem workItem);
        Task<IEnumerable<WorkItem>> GetAllAsync();
        Task<WorkItem> GetAsync(Guid workItemId);
        Task<WorkItem> Update(WorkItem workItem);
    }
}
