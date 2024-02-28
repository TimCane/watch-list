using WatchList.Core.Data;
using WatchList.Core.Entities.Identity;
using WatchList.Core.Repositories;

using WatchList.Identity.Repositories.Interfaces;

namespace WatchList.Identity.Repositories
{
    public class UserRepository : EfRepository<DbUser, DatabaseContext>, IUserRepository
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<DbUser?> GetByEmailAddress(string emailAddress)
        {
            return await FirstOrDefault(u => u.EmailAddress == emailAddress);
        }
    }
}
