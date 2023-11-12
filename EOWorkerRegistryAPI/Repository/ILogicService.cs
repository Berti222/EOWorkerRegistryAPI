using EOWorkerRegistryAPI.Model;
using System.Linq.Expressions;

namespace EOWorkerRegistryAPI.Repository
{
    public interface ILogicService<TEntity> where TEntity : IEntity
    {
        Task<TEntity> GetByIdAsync(long id);
        Task<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
