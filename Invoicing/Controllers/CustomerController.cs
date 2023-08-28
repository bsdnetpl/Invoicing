using Invoicing.DTO;
using Invoicing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomerController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        [HttpDelete("DeleteCustomer")]
        public async Task<bool> DeleteCustomer(Guid idUser)
        {
            return await _customerServices.DeleteCustomerAsync(idUser);
        }
        [HttpPost("AddCustomer")]
        public async Task<Customer> AddCustomerAsync(CustomerDTO customerDTO)
        {
            return await _customerServices.AddCustomerAsync(customerDTO);
        }
        [HttpPut("EditUser")]
        public async Task<bool> EditCustomerAsync(CustomerDTO customerDTO, Guid guid)
        {
            return await _customerServices.EditCustomerAsync(customerDTO, guid);
        }
        //[HttpGet("GetUserByNip")]
        //public async Task<List<Customer>> SeekCustomerByNip(string nip)
        //{
        //    return await _customerServices.SeekCustomerByNipAsync(nip);
        //}
    }
}
