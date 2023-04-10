using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Api.Controllers.Base;
using ShopsRUs.Core.Dtos;
using ShopsRUs.Core.Services;
using ShopsRUs.Core.UoW;

namespace ShopsRUs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly IDiscountService _discountService;

        public DiscountsController(IDiscountService discountService)
        {
            _discountService = discountService;
        }


        [HttpGet] //Müşterinin indirim oranını verir.   
        public async Task<IActionResult> CalculateDiscount(int customerId)
        {
            var response = await _discountService.CheckCustomer(customerId);
            return CreateActionResult(response);
        }
    }
}
