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
        private readonly IInvoceService _iinvoce;

        public InvoceController(IInvoceService iinvoce)
        {
            _iinvoce = iinvoce;
        }

        [HttpPost("CreateInvoceDB")]
        public ActionResult<InvoceDB>CreateInvoceDB(InvoceDB invoceDB)
        {
            invoceDB.InvoceNumber = _iinvoce.InvoceIncrement();
            return _iinvoce.addInvoceDB(invoceDB);
        }

        [HttpPost("CreateInvoce")]
        public ActionResult<string> CreateInvoce(string InvoceNumber)
        {
            return _iinvoce.addInvoce(InvoceNumber);
        }
    }
}
