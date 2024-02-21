using System.Linq.Expressions;
using WatchList.Core.Data.Entities;
using WatchList.Core.Data.Entities.Interfaces;
using WatchList.Core.Interfaces;

namespace WatchList.Core.Data.Repositories.Interfaces
{
    public interface IAsyncRepository<TEntity> where TEntity : IEntity
    {
        ValueTask<TEntity?> GetById(Guid id);
        Task<TEntity?> FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Remove(TEntity entity);
        Task RemoveRange(IEnumerable<TEntity> entities);

        Task<(IEnumerable<TEntity>, int)> GetAll(
            Expression<Func<TEntity, bool>>? expression = null,
            int? skip = null,
            int? take = null,
            IOrderBy? orderBy = null,
            int? sort = null
        );
        Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate);

        Task<int> CountAll();
        Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate);

        Task<bool> ExistsWhere(Expression<Func<TEntity, bool>> predicate);
    }
}
