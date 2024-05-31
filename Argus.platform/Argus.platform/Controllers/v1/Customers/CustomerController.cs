using Argus.Platform.Application.Companies.Companys;
using Argus.Platform.Application.Customers;
using Argus.Platform.Contract.V1;
using Argus.Platform.Controllers.v1.Companies.Dtos;
using Argus.Platform.Controllers.v1.Customers.Dtos;
using Argus.Platform.Core.Customers;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace Argus.Platform.Controllers.v1.Customers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
           _customerService = customerService;
        }

        [HttpGet(ApiRoutes.Customer.GetAll)]
        public async Task<IActionResult> GetAlCustomers()
        {
            var customer = await _customerService.GetAllCustomerAsync();
            return Ok(customer);
        }

        [HttpGet(ApiRoutes.Customer.Get)]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await _customerService.GetCustomerAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpPost(ApiRoutes.Customer.Create)]
        public async Task<IActionResult> AddCustomer(CustomerDto customerDto)
        {

            var customer = customerDto.Adapt<Customer>();

            var addedCustomer = await _customerService.AddCustomerAsync(customer);
            return CreatedAtAction(nameof(GetCustomer), new { id = addedCustomer.Id }, addedCustomer);
        }

        [HttpPut(ApiRoutes.Customer.Create)]
        public async Task<IActionResult> UpdateCustomer(Guid id, CustomerDto customerDto)
        {
            var existingCustomer = await _customerService.GetCustomerAsync(id);
            if (existingCustomer == null)
            {
                return NotFound();
            }

            existingCustomer = customerDto.Adapt<Customer>();

            var updatedCustomer = await _customerService.UpdateCustomerAsync(existingCustomer);
            return Ok(updatedCustomer);
        }
    }
}
