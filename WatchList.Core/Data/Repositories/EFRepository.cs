using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WatchList.Core.Data.Entities.Interfaces;
using WatchList.Core.Data.Repositories.Interfaces;

namespace WatchList.Core.Data.Repositories
{
    public class EfRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : class, IEntity
    {
        public readonly DatabaseContext Context;

        public EfRepository(DatabaseContext context)
        {
            Context = context;
        }

        public Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task Add(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public Task Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChangesAsync();
        }

        public Task Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public Task<int> CountAll()
        {
            return Context.Set<TEntity>().CountAsync();
        }

        public Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().CountAsync(predicate);
        }

        public Task<bool> ExistsWhere(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().AnyAsync(predicate);
        }

        public ValueTask<TEntity?> GetById(Guid id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }
    }
}
