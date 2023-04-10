using AutoMapper;
using ShopsRUs.Core.Dtos;
using ShopsRUs.Core.Repository.EntityFramework;
using ShopsRUs.Core.Repository;
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
    public class CustomerService : Service<Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork ofWork;

        public CustomerService(IGenericRepository<Customer> repository, IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository, IUnitOfWork ofWork) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            this.ofWork = ofWork;
        }
        public async Task<List<CustomerListDto>> GetAllCustomer()
        {
            var a = await ofWork.CustomerRepository.GetAllList();
            var customerList = await _customerRepository.GetAllList();
            var mappedDto = _mapper.Map<List<CustomerListDto>>(a);
            return mappedDto;
        }

    }
}
