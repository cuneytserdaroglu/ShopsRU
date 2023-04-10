﻿using Microsoft.EntityFrameworkCore;
using ShopsRUs.Core.Repository.EntityFramework;
using ShopsRUs.Domain.Concrete;

namespace ShopsRUs.Repository.Repositories.EntityFramework
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
        public async Task<Customer> GetByIdIncludeCustomerType(int customerId)
        {
          return  await _context.Customers.Include(x => x.CustomerType).Where(x => x.Id == customerId).FirstOrDefaultAsync(); 
        }

    }
}
