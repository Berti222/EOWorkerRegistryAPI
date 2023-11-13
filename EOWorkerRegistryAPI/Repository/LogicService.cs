using EOWorkerRegistryAPI.Model;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace EOWorkerRegistryAPI.Repository
{
    public class LogicService<TEntity> : ILogicService<TEntity> where TEntity : class, IEntity
    {
        private readonly WorkerRegisterContext context;

        public LogicService(WorkerRegisterContext context)
        {
            this.context = context;
        }
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.Active = true;
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            entity.Active = false;
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(long id)
        {
            return await context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id && e.Active);
        }

        public virtual async Task<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> predicate)
        {
            var query = context.Set<TEntity>()
                          .Where(e => e.Active);
            if (predicate != null)
                query = query.Where(predicate);
            return query;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
