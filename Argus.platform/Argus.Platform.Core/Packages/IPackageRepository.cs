using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Packages
{
    public interface IPackageRepository : IRepository<Package>, ITransientService
    {
        Package Add(Package package);
        Task<IEnumerable<Package>> GetAllAsync();
        Task<Package> GetAsync(Guid packageId);
        Task<Package> Update(Package package);
    }
}
