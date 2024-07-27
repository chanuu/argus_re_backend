using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Companies
{
    public interface ICompanyRepository : IRepository<Company>, IScopedService
    {
        Company Add(Company company);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetAsync(Guid companyId);
        Task<Company> Update(Company company);
    }
}
