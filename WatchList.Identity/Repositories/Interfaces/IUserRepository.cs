using WatchList.Core.Entities.Identity;
using WatchList.Core.Repositories;

namespace WatchList.Identity.Repositories.Interfaces
{
    public interface IUserRepository : IAsyncRepository<DbUser>
    {
        Task<DbUser?> GetByEmailAddress(string emailAddress);
    }
}
