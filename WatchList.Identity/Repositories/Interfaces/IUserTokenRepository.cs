using WatchList.Core.Repositories;
using WatchList.Identity.Entities;

namespace WatchList.Identity.Repositories.Interfaces
{
    public interface IUserTokenRepository : IAsyncRepository<DbUserToken>
    {
        public Task<DbUserToken?> GetValidUserToken(Guid userId, Guid id);
    }
}
