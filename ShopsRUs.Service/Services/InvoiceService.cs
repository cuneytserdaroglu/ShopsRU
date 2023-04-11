using AutoMapper;
using ShopsRUs.Core.Dtos;
using ShopsRUs.Core.Repository;
using ShopsRUs.Core.Repository.EntityFramework;
using ShopsRUs.Core.Services;
using ShopsRUs.Core.UoW;
using ShopsRUs.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Service.Services
{
    public class InvoiceService : Service<Invoice>, IInvoiceService
    {

        private readonly IDiscountService _discountService;
        private readonly IMapper _mapper;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceService(IGenericRepository<Invoice> repository, IUnitOfWork unitOfWork, IDiscountService discountService, IMapper mapper, IInvoiceRepository invoiceRepository) : base(repository, unitOfWork)
        {
            _discountService = discountService;
            _mapper = mapper;
            _invoiceRepository = invoiceRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomResponseDto<InvoiceDto>> Calculate(int customerId, decimal amount)
        {
            InvoiceDto dto = new InvoiceDto();
            dto.Amount = amount;
            dto.CustomerId = customerId;
            var discountRate = await _discountService.CheckCustomer(customerId);
            var discountForBill = _discountService.DiscountForBill(amount);
            dto.DiscountForBill = discountForBill.Data;
            dto.DiscountRate = discountRate.Data;

            dto.LastAmount = amount - (amount * discountRate.Data / 100) - discountForBill.Data;

            return CustomResponseDto<InvoiceDto>.Success(200, dto);
            //Discount controller'daki endpoint'lere de istek yapılabilir.
        }
        public async Task SaveInvoice(CustomResponseDto<InvoiceDto> dto)
        {
            var invoice = _mapper.Map<Invoice>(dto.Data);
            await _invoiceRepository.AddAsync(invoice);
            await _unitOfWork.CommitAsync();
        }
    }
}
