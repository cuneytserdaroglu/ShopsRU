using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopsRUs.Domain.Concrete.Base;

namespace ShopsRUs.Domain.Concrete
{
    public class Invoice : Entity
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int DiscountRate { get; set; }
        public decimal DiscountForBill { get; set; }
        public decimal LastAmount { get; set; }
    }
}
