using Argus.Platform.Core.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Companies.Companys
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyReposirory;
        public CompanyService(ICompanyRepository companyReposirory)
        {
            _companyReposirory = companyReposirory;
        }

        public async Task<IEnumerable<Company>> GetAllCompanyAsync()
        {
            return await _companyReposirory.GetAllAsync();
        }


        public async Task<Company> GetCompanyAsync(Guid companyId)
        {
            return await _companyReposirory.GetAsync(companyId);
        }

        public async Task<Company> AddCompanyAsync(Company _company)
        {
            // You may perform any necessary business logic validation here 
            var company = _companyReposirory.Add(_company);
            await _companyReposirory.UnitOfWork.SaveChangesAsync();
            return company;
        }

        public async Task<Company> UpdateCompanyAsync(Company _company)
        {
           
            var company = await _companyReposirory.Update(_company);
            await _companyReposirory.UnitOfWork.SaveChangesAsync();
            return company;
        }
    }
}
