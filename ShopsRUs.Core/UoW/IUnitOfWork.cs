using ShopsRUs.Core.Repository.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.UoW
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        void Commit();
        ICustomerRepository CustomerRepository { get; }
    }
}
