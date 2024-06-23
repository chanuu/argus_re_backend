using Argus.Platform.Core.Customers;
using Argus.Platform.Core.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Packages
{
    public class PackageService : IPackageService
    {
        private readonly IPackageRepository _packageRepository;
        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<IEnumerable<Package>> GetAllPackagesAsync()
        {
            return await _packageRepository.GetAllAsync();
        }


        public async Task<Package> GetPackageAsync(Guid packageId)
        {
            return await _packageRepository.GetAsync(packageId);
        }

        public async Task<Package> AddPackageAsync(Package _package)
        {
            var package = _packageRepository.Add(_package);
            await _packageRepository.UnitOfWork.SaveChangesAsync();
            return package;
        }

        public async Task<Package> UpdatePackageAsync(Package _package)
        {

            var package = await _packageRepository.Update(_package);
            await _packageRepository.UnitOfWork.SaveChangesAsync();
            return package;
        }
    }
}
