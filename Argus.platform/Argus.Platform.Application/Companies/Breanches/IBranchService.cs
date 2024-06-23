using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Companies.Breanches
{
    public interface IBranchService : ITransientService
    {
    
        Task<IEnumerable<Branch>> GetAllBranchAsync();
        Task<Branch> GetBranchAsync(Guid branchId);
        Task<Branch> AddBranchAsync(Branch _branch);
        Task<Branch> UpdateBranchAsync(Branch _branch);
    }
}
