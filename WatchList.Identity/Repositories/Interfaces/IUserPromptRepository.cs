using WatchList.Core.Entities.Identity;
using WatchList.Core.Repositories;

namespace WatchList.Identity.Repositories.Interfaces
{
    public interface IUserPromptRepository : IAsyncRepository<DbUserPrompt>
    {
        public Task<DbUserPrompt?> GetValidPasswordResetPrompt(Guid id);

        public Task<DbUserPrompt?> GetValidEmailVerficationPrompt(Guid id);
    }
}
