using Microsoft.EntityFrameworkCore;
using ShopsRUs.Core.Repository.EntityFramework;
using ShopsRUs.Domain.Concrete;
using ShopsRUs.Repository.Repositories.EntityFramework.Context;

namespace ShopsRUs.Repository.Repositories.EntityFramework
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Customer> GetByIdIncludeCustomerType(int customerId)
        {
          return  await _context.Customers.Include(x => x.CustomerType).Include(x => x.Discount).Where(x => x.Id == customerId).FirstOrDefaultAsync(); 
        }

    }
}
