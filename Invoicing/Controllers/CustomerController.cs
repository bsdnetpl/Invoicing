using FluentValidation;
using FluentValidation.Results;
using Invoicing.DTO;
using Invoicing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;
        private readonly IValidator<CustomerDTO> _validator;


        public CustomerController(ICustomerServices customerServices, IValidator<CustomerDTO> validator)
        {
            _customerServices = customerServices;
            _validator = validator;
        }
        [HttpDelete("DeleteCustomer")]
        public async Task<bool> DeleteCustomer(Guid idUser)
        {

                return await _customerServices.DeleteCustomerAsync(idUser);
            
        }
        [HttpPost("AddCustomer")]
        public async Task <ActionResult<Customer>> AddCustomerAsync([FromBody]  CustomerDTO customerDTO)
        {
        ValidationResult result = _validator.Validate(customerDTO);

            if (result.IsValid)
            {
                return await _customerServices.AddCustomerAsync(customerDTO);
            }
            return BadRequest(result);
        }
        [HttpPut("EditUser")]
        public async Task<ActionResult<bool>> EditCustomerAsync([FromBody]  CustomerDTO customerDTO, Guid guid)
        {
            if(guid == Guid.Empty) 
            {
                return BadRequest("Wrong guid !!");
            }
            ValidationResult result = _validator.Validate(customerDTO);

            if (result.IsValid)
            {
                return await _customerServices.EditCustomerAsync(customerDTO, guid);
            }
            return BadRequest(result);
        }
        [HttpGet("GetUserByNip")]
        public async Task<ActionResult<List<Customer>>> SeekCustomerByNip(string nip)
        {
            var result =  await _customerServices.SeekCustomerByNipAsync(nip);
            if(result.IsNullOrEmpty())
            {
                return BadRequest($"No client in db with nip number: {nip}");
            }
            return result;
        }
    }
}
