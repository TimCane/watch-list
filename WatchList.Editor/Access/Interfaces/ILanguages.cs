using WatchList.Core.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;

namespace WatchList.Editor.Access.Interfaces
{
    public interface ILanguages
    {
        Task<LanguagesResponse> Get(User user, PagedRequest request);

        Task<LanguageResponse> Get(User user, Guid id);

        Task<CreateLanguageResponse> Create(User user, CreateLanguageRequest request);

        Task<UpdateLanguageResponse> Update(User user, Guid id, UpdateLanguageRequest request);

        Task<DeleteLanguageResponse> Delete(User user, Guid id);
    }
}
