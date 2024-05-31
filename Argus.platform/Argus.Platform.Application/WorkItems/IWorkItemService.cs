using Argus.Platform.Core.Common;
using Argus.Platform.Core.Packages;
using Argus.Platform.Core.WorkItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.WorkItems
{
    public interface IWorkItemService : ITransientService
    {
        Task<IEnumerable<WorkItem>> GetAllWorkItemAsync();
        Task<WorkItem> GetWorkItemAsync(Guid workItemId);
        Task<WorkItem> AddWorkItemAsync(WorkItem _workItem);
        Task<WorkItem> UpdateWorkItemAsync(WorkItem _workItem);
    }
}
