using WatchList.Core.Repositories;
using WatchList.Identity.Entities;

namespace WatchList.Identity.Repositories.Interfaces
{
    public interface IUserRepository : IAsyncRepository<DbUser>
    {
        Task<DbUser?> GetByEmailAddress(string emailAddress);
    }
}
