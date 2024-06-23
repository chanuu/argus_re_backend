using Argus.Platform.Core.Common;
using Argus.Platform.Core.JobsWorkflowEvents;
using Argus.Platform.Core.Packages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.JobsWorkflowEvents
{
    public class JobsWorkflowEventRepository :IJobsWorkflowEventRepository
    {
        private readonly ApiContext _context;

        public JobsWorkflowEventRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public JobsWorkflowEvent Add(JobsWorkflowEvent jobsWorkflowEvent)
        {
            return _context.JobsWorkflowEvents.Add(jobsWorkflowEvent).Entity;
        }


        public async Task<IEnumerable<JobsWorkflowEvent>> GetAllAsync()
        {
            return await _context.JobsWorkflowEvents.ToListAsync();
        }

        public async Task<JobsWorkflowEvent> GetAsync(Guid jobsWorkflowEventId)
        {
            return await _context.JobsWorkflowEvents.SingleOrDefaultAsync();
        }

        public async Task<JobsWorkflowEvent> Update(JobsWorkflowEvent jobsWorkflowEvent)
        {
            _context.JobsWorkflowEvents.Update(jobsWorkflowEvent);

            await _context.SaveChangesAsync();

            return jobsWorkflowEvent;
        }

    }
}
