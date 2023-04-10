using AutoMapper;
using ShopsRUs.Core;
using ShopsRUs.Core.Dtos;
using ShopsRUs.Core.Exceptions;
using ShopsRUs.Core.Repository;
using ShopsRUs.Core.Repository.EntityFramework;
using ShopsRUs.Core.Services;
using ShopsRUs.Core.UoW;
using ShopsRUs.Domain.Concrete;
using ShopsRUs.Service.BusinessRules.Discount;

namespace ShopsRUs.Service.Services
{
    public class DiscountService : Service<Discount>, IDiscountService
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork ofWork;
        private readonly DiscountBusinessRule _discountBusinessRule;

        public DiscountService(IGenericRepository<Discount> repository, IUnitOfWork unitOfWork, IMapper mapper, IDiscountService customerRepository, IUnitOfWork ofWork, DiscountBusinessRule discountBusinessRule) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _discountRepository = _discountRepository;
            this.ofWork = ofWork;
            _discountBusinessRule = discountBusinessRule;
        }

        public async Task<CustomResponseDto<int>> CheckCustomer(int customerId)
        {
            var customer = await ofWork.CustomerRepository.GetByIdAsync(customerId);
            if (customer == null)
                throw new BusinessException(GlobalConst.NotFoundCustomer);
            var isEmployee = await _discountBusinessRule.isEmplooyeOfStore(customer);
            if (isEmployee.Keys.FirstOrDefault())
            {
                return CustomResponseDto<int>.Success(200, isEmployee.Values.FirstOrDefault());
            }
            var isMember = await _discountBusinessRule.isEmplooyeOfStore(customer);
            return CustomResponseDto<int>.Success(200, isMember.Values.FirstOrDefault());

        }
    }
}
