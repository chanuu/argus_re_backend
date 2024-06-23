using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Companies.Companys
{
    public interface ICompanyService : ITransientService
    {
        Task<IEnumerable<Company>> GetAllCompanyAsync();
        Task<Company> GetCompanyAsync(Guid companyId);
        Task<Company> AddCompanyAsync(Company _company);
        Task<Company> UpdateCompanyAsync(Company _company);
    }
}
