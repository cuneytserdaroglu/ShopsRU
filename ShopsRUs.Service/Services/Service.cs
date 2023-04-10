using ShopsRUs.Core.Repository;
using ShopsRUs.Core.Services;
using ShopsRUs.Core.UoW;
using System.Linq.Expressions;

namespace ShopsRUs.Service.Services
{
    public class Service<T> : IService<T> where T : class, new()
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenericRepository<T> _repository;

        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public async Task<T> AddAsync(T entity)
        {

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> filter = null)
        {
            return await _repository.AnyAsync(filter);
        }

        public async Task DeleteAsync(T entity)
        {
            _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IQueryable<T>> GetAllAsQueryableList(Expression<Func<T, bool>> filter = null)
        {
            return await _repository.GetAllAsQueryableList(filter);
        }

        public async Task<List<T>> GetAllList(Expression<Func<T, bool>> filter = null)
        {
            return await _repository.GetAllList(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async void RemoveRange(IEnumerable<T> entities)
        {
            _repository.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(T entity)
        {
            _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }
    }
}
