using Microsoft.EntityFrameworkCore;
using WatchList.Core.Repositories;
using WatchList.Identity.Data;
using WatchList.Identity.Entities;
using WatchList.Identity.Enums;
using WatchList.Identity.Repositories.Interfaces;

namespace WatchList.Identity.Repositories
{
    public class UserPromptRepository : EfRepository<DbUserPrompt, IdentityContext>, IUserPromptRepository
    {
        public UserPromptRepository(IdentityContext context) : base(context)
        {
        }

        public async Task<DbUserPrompt?> GetValidPasswordResetPrompt(Guid id)
        {
            return await
                Context.DbUserPrompts
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(r =>
                        r.Id == id &&
                        r.Type == DbUserPromptTypeEnum.PasswordReset &&
                        r.Status == DbUserPromptStatusEnum.Pending &&
                        r.CreatedOn > DateTime.UtcNow.AddDays(-3)
                    );
        }

        public async Task<DbUserPrompt?> GetValidEmailVerficationPrompt(Guid id)
        {
            return await
                Context.DbUserPrompts
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(r =>
                        r.Id == id &&
                        r.Type == DbUserPromptTypeEnum.EmailVerification &&
                        r.Status == DbUserPromptStatusEnum.Pending &&
                        r.CreatedOn > DateTime.UtcNow.AddDays(-3)
                    );
        }
    }
}
