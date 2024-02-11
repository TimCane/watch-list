using WatchList.Core.Data.Entities;
using WatchList.Core.Data.Repositories.Interfaces;

namespace WatchList.Core.Data.Repositories
{
    public class UserRepository : EfRepository<DbUser>, IUserRepository
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
