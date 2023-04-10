using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRUs.Core.Repository
{
    public interface IGenericRepository<T> where T : class, new()
    {
        Task<T> GetByIdAsync(int id);
        Task<IQueryable<T>> GetAllAsQueryableList(Expression<Func<T, bool>> filter = null);
        Task<List<T>> GetAllList(Expression<Func<T, bool>> filter = null);
        Task AddAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null);
        void Update(T entity);
        void Delete(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void RemoveRange(IEnumerable<T> entities);
    }
}
