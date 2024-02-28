using WatchList.Core.Entities.Identity;
using WatchList.Core.Repositories;

namespace WatchList.Identity.Repositories.Interfaces
{
    public interface IUserTokenRepository : IAsyncRepository<DbUserToken>
    {
        public Task<DbUserToken?> GetValidUserToken(Guid userId, Guid id);
    }
}
