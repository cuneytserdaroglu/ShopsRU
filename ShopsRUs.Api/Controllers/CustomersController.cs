using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopsRUs.Api.Controllers.Base;
using ShopsRUs.Core.Dtos;
using ShopsRUs.Core.Services;

namespace ShopsRUs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : CustomBaseController
    {
        private readonly ICustomerService _customerservice;
        public CustomersController(ICustomerService service)
        {
            _customerservice = service;
        }

        [HttpGet]
        public async Task<IActionResult> AllCustomer()
        {
            var customrListDto = await _customerservice.GetAllCustomer();
            return CreateActionResult(CustomResponseDto<List<CustomerListDto>>.Success(200, customrListDto));
        }

        


    }
}
