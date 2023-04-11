using AutoMapper;
using ShopsRUs.Core;
using ShopsRUs.Core.Dtos;
using ShopsRUs.Core.Exceptions;
using ShopsRUs.Core.Repository;
using ShopsRUs.Core.Repository.EntityFramework;
using ShopsRUs.Core.Services;
using ShopsRUs.Core.UoW;
using ShopsRUs.Domain.Concrete;
using ShopsRUs.Repository.Repositories.EntityFramework;
using ShopsRUs.Service.BusinessRules.Discount;

namespace ShopsRUs.Service.Services
{
    public class DiscountService : Service<Discount>, IDiscountService
    {
        private readonly DiscountBusinessRule _discountBusinessRule;
        private readonly IUnitOfWork ofWork;
        public DiscountService(IGenericRepository<Discount> repository, IUnitOfWork unitOfWork, DiscountBusinessRule discountBusinessRule, IUnitOfWork ofWork) : base(repository, unitOfWork)
        {
            _discountBusinessRule = discountBusinessRule;
            this.ofWork = ofWork;
        }

        public async Task<CustomResponseDto<int>> CheckCustomer(int customerId)
        {
            var a = 0;
            var b = 10 / a;
            var customer = await ofWork.CustomerRepository.GetByIdIncludeCustomerType(customerId);
            if (customer == null)
              return CustomResponseDto<int>.Fail(404,GlobalConst.NotFoundCustomer);
            var isEmployee = await _discountBusinessRule.isEmplooyeOfStore(customer);
            if (isEmployee.Keys.FirstOrDefault())
            {
                return CustomResponseDto<int>.Success(200, isEmployee.Values.FirstOrDefault());
            }
            var isMember = await _discountBusinessRule.isMemberOfStore(customer);
            return CustomResponseDto<int>.Success(200, isMember.Values.FirstOrDefault());
        }

        public CustomResponseDto<decimal> DiscountForBill(decimal price)
        {
            var discountRate = Math.Floor((price / 100));
            var discountTotal = discountRate * GlobalConst.DiscountAmount;
            return CustomResponseDto<decimal>.Success(200,discountTotal);
        }
    }
}
