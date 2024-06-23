using Argus.Platform.Core.Common;
using Argus.Platform.Core.Packages;
using Argus.Platform.Core.WorkItems;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.WorkItems
{
    public class WorkItemRepository : IWorkItemRepsitory
    {
        private readonly ApiContext _context;

        public WorkItemRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public WorkItem Add(WorkItem workItem)
        {
            return _context.WorkItems.Add(workItem).Entity;
        }


        public async Task<IEnumerable<WorkItem>> GetAllAsync()
        {
            return await _context.WorkItems.ToListAsync();
        }

        public async Task<WorkItem> GetAsync(Guid workItemId)
        {
            return await _context.WorkItems.SingleOrDefaultAsync();
        }

        public async Task<WorkItem> Update(WorkItem workItem)
        {
            _context.WorkItems.Update(workItem);

            await _context.SaveChangesAsync();

            return workItem;
        }
    }
}
