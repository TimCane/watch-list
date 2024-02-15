using WatchList.Core.Data.Entities;

namespace WatchList.Core.Data.Repositories.Interfaces
{
    public interface IUserTokenRepository : IAsyncRepository<DbUserToken>
    {
        public Task<DbUserToken?> GetValidUserToken(Guid userId, Guid id);
    }
}
