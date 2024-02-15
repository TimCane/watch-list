using Microsoft.EntityFrameworkCore;
using WatchList.Core.Data.Entities;
using WatchList.Core.Data.Entities.Enums;
using WatchList.Core.Data.Repositories.Interfaces;

namespace WatchList.Core.Data.Repositories
{
    public class UserTokenRepository : EfRepository<DbUserToken>, IUserTokenRepository
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
