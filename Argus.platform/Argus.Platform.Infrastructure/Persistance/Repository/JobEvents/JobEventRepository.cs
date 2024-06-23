using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using Argus.Platform.Core.JobEvents;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.JobEvents
{
    public class JobEventRepository : IJobEventRepository
    {
        private readonly ApiContext _context;

        public JobEventRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public JobEvent Add(JobEvent jobEvent)
        {
            return _context.JobEvents.Add(jobEvent).Entity;
        }


        public async Task<IEnumerable<JobEvent>> GetAllAsync()
        {
            return await _context.JobEvents.ToListAsync();
        }

        public async Task<JobEvent> GetAsync(Guid jobEventId)
        {
            return await _context.JobEvents.SingleOrDefaultAsync();
        }

        public async Task<JobEvent> Update(JobEvent jobEvent)
        {
            _context.JobEvents.Update(jobEvent);

            await _context.SaveChangesAsync();

            return jobEvent;
        }

        
    }
}
