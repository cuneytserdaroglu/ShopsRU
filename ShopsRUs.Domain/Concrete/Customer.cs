﻿using ShopsRUs.Domain.Concrete.Base;

namespace ShopsRUs.Domain.Concrete
{
    public class Customer : Entity
    {
        public string Name { get; set; }
        public int CustomerTypeId { get; set; }
        public int DiscountId { get; set; }
        public virtual CustomerType CustomerType { get; set; }
        public virtual Discount Discount { get; set; }

    }
}
