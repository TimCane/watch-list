using WatchList.Core.Repositories;
using WatchList.Identity.Data;
using WatchList.Identity.Entities;
using WatchList.Identity.Repositories.Interfaces;

namespace WatchList.Identity.Repositories
{
    public class UserRepository : EfRepository<DbUser, IdentityContext>, IUserRepository
    {
        public UserRepository(IdentityContext context) : base(context)
        {
        }

        public async Task<DbUser?> GetByEmailAddress(string emailAddress)
        {
            return await FirstOrDefault(u => u.EmailAddress == emailAddress);
        }
    }
}
