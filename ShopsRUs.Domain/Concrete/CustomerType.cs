using ShopsRUs.Domain.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Domain.Concrete
{
    public class CustomerType : Entity
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }

    }

}
