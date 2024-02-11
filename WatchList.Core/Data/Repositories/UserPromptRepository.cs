using Microsoft.EntityFrameworkCore;
using WatchList.Core.Data.Entities;
using WatchList.Core.Data.Entities.Enums;
using WatchList.Core.Data.Repositories.Interfaces;

namespace WatchList.Core.Data.Repositories
{
    public class UserPromptRepository : EfRepository<DbUserPrompt>, IUserPromptRepository
    {
        public UserPromptRepository(DatabaseContext context) : base(context)
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
                        r.Used == false &&
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
                        r.Used == false
                    );
        }
    }
}
