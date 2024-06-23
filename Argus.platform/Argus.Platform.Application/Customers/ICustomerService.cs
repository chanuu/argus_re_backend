using Argus.Platform.Core.Common;
using Argus.Platform.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Customers
{
    public interface ICustomerService : IScopedService
    {
        Task<IEnumerable<Customer>> GetAllCustomerAsync();
        Task<Customer> GetCustomerAsync(Guid customerId);
        Task<Customer> AddCustomerAsync(Customer _customer);
        Task<Customer> UpdateCustomerAsync(Customer _customer);
    }
}
