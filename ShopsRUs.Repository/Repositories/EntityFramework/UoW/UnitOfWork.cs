using ShopsRUs.Core.Repository.EntityFramework;
using ShopsRUs.Core.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Repository.Repositories.EntityFramework.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            CustomerRepository = new CustomerRepository(context);
            DiscountRepository= new DiscountRepository(context);
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }


        #region Db
        public ICustomerRepository CustomerRepository { get; }

        public IDiscountRepository DiscountRepository { get; }



        #endregion


    }
}
