using ShopsRUs.Core.Dtos;
using ShopsRUs.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Services
{
    public interface ICustomerService : IService<Customer>
    {
        Task<List<CustomerListDto>> GetAllCustomer();
    }
}
