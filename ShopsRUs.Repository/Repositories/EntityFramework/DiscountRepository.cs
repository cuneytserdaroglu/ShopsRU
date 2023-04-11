using ShopsRUs.Core.Repository.EntityFramework;
using ShopsRUs.Domain.Concrete;
using ShopsRUs.Repository.Repositories.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Repository.Repositories.EntityFramework
{
    public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(AppDbContext context) : base(context)
        {
        }
    }
}
