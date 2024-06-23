using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Companies
{
    public interface IBranchRepository : IRepository<Branch>, ITransientService
    {
       Task<IEnumerable<Branch>> GetAllAsync();
       Branch Add(Branch branch);
       Task<Branch> GetAsync(Guid branchId);
       Task<Branch> Update(Branch branch);
    }
}
