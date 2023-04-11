using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Dtos
{
    public class InvoiceDto
    {
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
        public int DiscountRate { get; set; }
        public decimal DiscountForBill { get; set; }
        public decimal LastAmount { get; set; }
    }
}
