using WatchList.Core.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;

namespace WatchList.Editor.Access.Interfaces
{
    public interface IKeywords
    {
        Task<KeywordsResponse> Get(User user, PagedRequest request);

        Task<KeywordResponse> Get(User user, Guid id);

        Task<CreateKeywordResponse> Create(User user, CreateKeywordRequest request);

        Task<UpdateKeywordResponse> Update(User user, Guid id, UpdateKeywordRequest request);

        Task<DeleteKeywordResponse> Delete(User user, Guid id);
    }
}
