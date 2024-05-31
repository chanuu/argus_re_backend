using Argus.Platform.Core.Companies;
using Argus.Platform.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Argus.Platform.Application.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
        {
            return await _customerRepository.GetAllAsync();
        }


        public async Task<Customer> GetCustomerAsync(Guid customerId)
        {
            return await _customerRepository.GetAsync(customerId);
        }

        public async Task<Customer> AddCustomerAsync(Customer _customer)
        {          
            var customer = _customerRepository.Add(_customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomerAsync(Customer _customer)
        {

            var customer = await _customerRepository.Update(_customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync();
            return customer;
        }
    }
}
