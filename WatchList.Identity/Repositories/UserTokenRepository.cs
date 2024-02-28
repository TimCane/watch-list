using Microsoft.EntityFrameworkCore;
using WatchList.Core.Data;
using WatchList.Core.Entities.Identity;
using WatchList.Core.Repositories;
using WatchList.Identity.Repositories.Interfaces;

namespace WatchList.Identity.Repositories
{
    public class UserTokenRepository : EfRepository<DbUserToken, DatabaseContext>, IUserTokenRepository
    {
        public UserTokenRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<DbUserToken?> GetValidUserToken(Guid userId, Guid id)
        {
            return await
                Context.DbUserTokens
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(r =>
                        r.Id == id
                    );
        }
    }
}
