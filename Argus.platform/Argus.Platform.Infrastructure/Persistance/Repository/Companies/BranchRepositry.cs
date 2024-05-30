using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Companies
{
    public class BranchRepositry : IBranchRepository
    {
        private readonly ApiContext _context;

        public BranchRepositry(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Branch Add(Branch branch)
        {
            return _context.Branches.Add(branch).Entity;
        }


        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch> GetAsync(Guid branchId)
        {
            return await _context.Branches.SingleOrDefaultAsync();
        }

        public async Task<Branch> Update(Branch branch)
        {
            _context.Branches.Update(branch);

            await _context.SaveChangesAsync();

            return branch;
        }
    }
}
