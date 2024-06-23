using Argus.Platform.Core.Packages;
using Argus.Platform.Core.WorkItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.WorkItems
{
    public class WorkItemService : IWorkItemService
    {
       
        private readonly IWorkItemRepsitory _workItemRepsitory;
        public WorkItemService(IWorkItemRepsitory workItemRepsitory) 
        {
            _workItemRepsitory = workItemRepsitory;
        }
        public async Task<IEnumerable<WorkItem>> GetAllWorkItemAsync()
        {
            return await  _workItemRepsitory.GetAllAsync();
        }


        public async Task<WorkItem> GetWorkItemAsync(Guid workItemId)
        {
            return await _workItemRepsitory.GetAsync(workItemId);
        }

        public async Task<WorkItem> AddWorkItemAsync(WorkItem _workItem)
        {
            var workItem = _workItemRepsitory.Add(_workItem);
            await _workItemRepsitory.UnitOfWork.SaveChangesAsync();
            return workItem;
        }

        public async Task<WorkItem> UpdateWorkItemAsync(WorkItem _workItem)
        {

            var workItem = await _workItemRepsitory.Update(_workItem);
            await _workItemRepsitory.UnitOfWork.SaveChangesAsync();
            return workItem;
        }
    }
}
