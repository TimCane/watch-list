using Microsoft.EntityFrameworkCore;
using WatchList.Core.Repositories;
using WatchList.Identity.Data;
using WatchList.Identity.Entities;
using WatchList.Identity.Repositories.Interfaces;

namespace WatchList.Identity.Repositories
{
    public class UserTokenRepository : EfRepository<DbUserToken, IdentityContext>, IUserTokenRepository
    {
        public UserTokenRepository(IdentityContext context) : base(context)
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
