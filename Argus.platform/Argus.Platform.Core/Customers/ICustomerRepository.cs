using Argus.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Core.Customers
{
    public interface ICustomerRepository : IRepository<Customer>, ITransientService
    {
        Customer Add(Customer customer);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> GetAsync(Guid customerId);
        Task<Customer> Update(Customer customer);
    }
}
