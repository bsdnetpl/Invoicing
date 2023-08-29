using FluentValidation.Results;
using Invoicing.DTO;
using Invoicing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerServices _servicesSeller;
        private readonly SellerValidation _validationRules;


        public SellerController(ISellerServices servicesSeller, SellerValidation validationRules)
        {
            _servicesSeller = servicesSeller;
            _validationRules = validationRules;
        }
        [HttpPost("AddSeller")]
        public async Task<ActionResult<Seller>> AddSeller([FromBody] Seller seller)
        {
            ValidationResult result = _validationRules.Validate(seller);
            if (result.IsValid)
            {
              await  _servicesSeller.AddSellerAsync(seller);
              return seller;
            }
            return BadRequest();
        }
    }
}
