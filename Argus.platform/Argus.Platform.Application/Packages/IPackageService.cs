using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using Argus.Platform.Core.Packages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Packages
{
    public interface IPackageService : ITransientService
    {
        Task<IEnumerable<Package>> GetAllPackagesAsync();
        Task<Package> GetPackageAsync(Guid packageId);
        Task<Package> AddPackageAsync(Package _package);
        Task<Package> UpdatePackageAsync(Package _package);
    }
}
