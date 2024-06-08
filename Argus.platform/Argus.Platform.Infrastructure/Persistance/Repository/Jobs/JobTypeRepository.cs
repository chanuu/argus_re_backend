using Argus.Platform.Core.Common;
using Argus.Platform.Core.Jobs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Jobs
{
    public class JobTypeRepository: IJobTypeRepository
    {
        private readonly ApiContext _context;

        public JobTypeRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public JobType Add(JobType jobType)
        {
            return _context.JobTypes.Add(jobType).Entity;
        }

        public async Task<IEnumerable<JobType>> GetAllAsync()
        {
            return await _context.JobTypes.Include(d => d.Job).ToListAsync();
        }

        public async Task<JobType> GetAsync(Guid jobTypeId)
        {
            return await _context.JobTypes
                                 .Include(d => d.Job)
                                 .SingleOrDefaultAsync(dt => dt.Id == jobTypeId);
        }
       
        public async Task<JobType> Update(JobType jobType)
        {
            _context.JobTypes.Update(jobType);
            await _context.SaveChangesAsync();
            return jobType;
        }
    }
}
