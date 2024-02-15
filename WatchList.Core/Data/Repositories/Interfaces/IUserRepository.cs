using WatchList.Core.Data.Entities;

namespace WatchList.Core.Data.Repositories.Interfaces
{
    public interface IUserRepository : IAsyncRepository<DbUser>
    {
        Task<DbUser?> GetByEmailAddress(string emailAddress);
    }
}
