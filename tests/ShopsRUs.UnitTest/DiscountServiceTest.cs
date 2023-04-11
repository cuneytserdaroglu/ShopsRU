using Moq;
using ShopsRUs.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.UnitTest
{
    public class DiscountServiceTest
    {
        private readonly Mock<IDiscountService> _mockDiscountService;
        private readonly int _customerId;
        private readonly decimal _amount;

        public DiscountServiceTest()
        {
            _mockDiscountService = new Mock<IDiscountService>();
            _customerId = 1;
            _amount = 1000;
        }

        //[Fact]
        //public async void should_return_exception_when_customerid_doesnt_exist
        //{
          
        //}
    }
}
