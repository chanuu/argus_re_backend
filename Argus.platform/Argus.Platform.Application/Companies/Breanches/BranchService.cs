using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Companies.Breanches
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        public BranchService(IBranchRepository branchRepository)

        {
            _branchRepository = branchRepository;
        }


        public async Task<Branch> AddBranchAsync(Branch _branch)
        {

            var branch = _branchRepository.Add(_branch);
            await _branchRepository.UnitOfWork.SaveChangesAsync();
            return branch;
        }

        public async Task<IEnumerable<Branch>> GetAllBranchAsync()
        {
            return await _branchRepository.GetAllAsync();
        }

        public async Task<Branch> GetBranchAsync(Guid branchId)
        {
            return await _branchRepository.GetAsync(branchId);
        }

        public async Task<Branch> UpdateBranchAsync(Branch _branch)
        {
            var branch = await _branchRepository.Update(_branch);
            await _branchRepository.UnitOfWork.SaveChangesAsync();
            return branch;
        }
    }
}