using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Documents;
using Argus.Platform.Core.Jobs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Jobs
{
    public class JobRepository : IJobRepository
    {

        private readonly ApiContext _context;

        public JobRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Job  Add(Job job)
        {           
            return _context.Jobs.Add(job).Entity;
        }

      
        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await _context.Jobs.Include(x => x.JobType).ToListAsync();

        }

        public async Task<Job> GetAsync(Guid jobId)
        {
            return await _context.Jobs.SingleOrDefaultAsync();
        }

        public async Task<Job> Update(Job job)
        {

            _context.Jobs.Update(job);

            await _context.SaveChangesAsync();

            return job;
        }
    }
}
