using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using Argus.Platform.Core.Packages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Infrastructure.Persistance.Repository.Packages
{
    public class PackageRepository : IPackageRepository
    {
        private readonly ApiContext _context;

        public PackageRepository(ApiContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _context; }
        }

        public Package Add(Package package)
        {
            return _context.Packages.Add(package).Entity;
        }


        public async Task<IEnumerable<Package>> GetAllAsync()
        {
            return await _context.Packages.ToListAsync();
        }

        public async Task<Package> GetAsync(Guid packageId)
        {
            return await _context.Packages.SingleOrDefaultAsync();
        }

        public async Task<Package> Update(Package package)
        {
            _context.Packages.Update(package);

            await _context.SaveChangesAsync();

            return package;
        }
    }
}
