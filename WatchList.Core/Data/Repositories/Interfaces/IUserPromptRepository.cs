using WatchList.Core.Data.Entities;

namespace WatchList.Core.Data.Repositories.Interfaces
{
    public interface IUserPromptRepository : IAsyncRepository<DbUserPrompt>
    {
        public Task<DbUserPrompt?> GetValidPasswordResetPrompt(Guid id);

        public Task<DbUserPrompt?> GetValidEmailVerficationPrompt(Guid id);
    }
}
