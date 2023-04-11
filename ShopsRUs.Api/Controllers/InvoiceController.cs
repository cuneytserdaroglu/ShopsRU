using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Api.Controllers.Base;
using ShopsRUs.Core.Services;

namespace ShopsRUs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : CustomBaseController
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> Calculate(int customerId, decimal amount)
        {
            var response = await _invoiceService.Calculate(customerId, amount);
            await _invoiceService.SaveInvoice(response);
            return CreateActionResult(response);
        }
    }
}
