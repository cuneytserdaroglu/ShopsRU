using ShopsRUs.Core;
using ShopsRUs.Core.Exceptions;
using ShopsRUs.Core.UoW;
using ShopsRUs.Domain.Concrete;
using ShopsRUs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShopsRUs.Service.BusinessRules.Discount
{
    public class DiscountBusinessRule : BaseBusinessRules
    {
        private IUnitOfWork _unitOfWork;
        //protected Customer _customer;

        //protected Customer Customer
        //{
        //    get { return _customer; }
        //    set { _customer = value; }
        //}


        public DiscountBusinessRule(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<bool, int>> isEmplooyeOfStore(Customer customer)
        {

            if (customer.CustomerTypeId == (int)CustomerTypes.Employee)
            {
                return new Dictionary<bool, int>() { { true, customer.CustomerType.Discount.DiscountRate } };
            }
            else
            {
                //Customer = customer;
                return new Dictionary<bool, int>() { { false, new int() } };
            }
        }

        public async Task<Dictionary<bool, int>> isMemberOfStore(Customer customer)
        {
            //Customer = Customer == null ? await _unitOfWork.CustomerRepository.GetByIdIncludeCustomerType(customerId) : Customer;
            //if (customer == null)
            //    throw new BusinessException(GlobalConst.NotFoundCustomer);
            if ( customer.CustomerTypeId == (int)CustomerTypes.Member)
            {
                if (customer.CreatedDate < DateTime.Now.AddYears(-2)) //2 yıldan beri müşteriyse %5 indirim alır
                    return new Dictionary<bool, int>() { { true, customer.CustomerType.Discount.DiscountRate / 2 } };
                else
                    return new Dictionary<bool, int>() { { true, customer.CustomerType.Discount.DiscountRate} };
            }
            else
            {
                return new Dictionary<bool, int>() { { false,new int() } };
            }
        }
    }
}
