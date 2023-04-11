using ShopsRUs.Core.Dtos;
using ShopsRUs.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Services
{
    public interface IInvoiceService : IService<Invoice>
    {
        Task<CustomResponseDto<InvoiceDto>> Calculate(int customerId, decimal amount);
        Task SaveInvoice(CustomResponseDto<InvoiceDto> dto);
    }
}
