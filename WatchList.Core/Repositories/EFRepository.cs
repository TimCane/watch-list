using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WatchList.Core.Entities.Interfaces;
using WatchList.Core.Extensions;
using WatchList.Core.Interfaces;

namespace WatchList.Core.Repositories
{
    public class EfRepository<TEntity, TContext> : IAsyncRepository<TEntity> where TEntity : class, IIdEntity where TContext : DbContext
    {
        public readonly TContext Context;

        public EfRepository(TContext context)
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

        public Task RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            return Context.SaveChangesAsync();
        }

        public async Task<(IEnumerable<TEntity>, int)> GetAll(Expression<Func<TEntity, bool>>? expression = null, int? skip = null, int? take = null, IOrderBy? orderBy = null, int? sort = null)
        {
            var data = Context.Set<TEntity>().AsQueryable();

            if (expression != null)
            {
                data = data.Where(expression);
            }

            var total = data.Count();

            if (orderBy != null && sort.HasValue)
            {
                data = sort.Value == 0
                    ? data.OrderBy(orderBy)
                    : data.OrderByDescending(orderBy);
            }

            if (skip.HasValue && take.HasValue)
            {
                data = data.Skip(skip.Value)
                    .Take(take.Value);
            }

            return (data, total);
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
