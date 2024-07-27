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
            return await _context.Company.SingleOrDefaultAsync(c => c.Id == companyId);
        }

        public async Task<Company> Update(Company company )
        {          
            var existingCopany = await _context.Company.FindAsync(company.Id);
            if (existingCopany != null)
            {
                _context.Entry(existingCopany).CurrentValues.SetValues(company);
            }
            await _context.SaveChangesAsync();
            return existingCopany;
        }
    }
}
