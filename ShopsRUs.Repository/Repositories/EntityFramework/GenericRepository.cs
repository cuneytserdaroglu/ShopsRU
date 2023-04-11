using Microsoft.EntityFrameworkCore;
using ShopsRUs.Core.Repository;
using ShopsRUs.Repository.Repositories.EntityFramework.Context;
using System.Linq.Expressions;

namespace ShopsRUs.Repository.Repositories.EntityFramework
{

    public class GenericRepository<T> : IGenericRepository<T>
        where T : class, new()
    {
        protected readonly DbSet<T> _dbSet;

        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }


        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null)
        {
            return await _dbSet.AnyAsync(filter);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IQueryable<T>> GetAllAsQueryableList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ?
                  _dbSet.AsNoTracking().AsQueryable()
                    : _dbSet.AsNoTracking().Where(filter).AsQueryable();
        }

        public async Task<List<T>> GetAllList(Expression<Func<T, bool>> filter = null)
        {
            return filter == null ?
                  await _dbSet.AsNoTracking().ToListAsync()
                    : await _dbSet.AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
