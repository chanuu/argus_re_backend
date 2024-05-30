using Argus.Platform.Core.Common;
using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Complience.Audits;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Companies
{
    public class CompanyRepsitory : ICompanyRepository
    {
        private readonly ApiContext _context;

        public CompanyRepsitory(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Company Add(Company company)
        {
            return _context.Company.Add(company).Entity;
        }


        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Company.ToListAsync();
        }

        public async Task<Company> GetAsync(Guid companyId)
        {
            return await _context.Company.SingleOrDefaultAsync();
        }

        public async Task<Company> Update(Company company )
        {
            _context.Company.Update(company);

            await _context.SaveChangesAsync();

            return company;
        }
    }
}
