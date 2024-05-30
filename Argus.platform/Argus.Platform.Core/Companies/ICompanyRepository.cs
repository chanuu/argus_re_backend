using Argus.Platform.Core.Common;
using Argus.Platform.Core.Complience.Audits;
using Argus.Platform.Core.Complience.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Companies
{
    public interface ICompanyRepository : IRepository<Company>, ITransientService
    {
        Company Add(Company company);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetAsync(Guid companyId);
        Task<Company> Update(Company company);
    }
}
