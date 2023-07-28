using Invoicing.DTO;
using Invoicing.Models;
using Invoicing.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Invoicing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoceController : ControllerBase
    {
        private readonly IInvoce _iinvoce;

        public InvoceController(IInvoce iinvoce)
        {
            _iinvoce = iinvoce;
        }

        [HttpPost("CreateInvoceDB")]
        public ActionResult<InvoceDB>CreateInvoceDB(InvoceDB invoceDB)
        {
            return _iinvoce.addInvoceDB(invoceDB);
        }


        [HttpPost("CreateInvoce")]
        public ActionResult<Invoce> CreateInvoce(string InvoceNumber)
        {
            return _iinvoce.addInvoce(InvoceNumber);
        }

    }
}
