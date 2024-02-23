using WatchList.Core.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;

namespace WatchList.Editor.Access.Interfaces
{
    public interface ICollections
    {
        Task<CollectionsResponse> Get(User user, PagedRequest request);

        Task<CollectionResponse> Get(User user, Guid id);

        Task<CreateCollectionResponse> Create(User user, CreateCollectionRequest request);

        Task<UpdateCollectionResponse> Update(User user, Guid id, UpdateCollectionRequest request);

        Task<DeleteCollectionResponse> Delete(User user, Guid id);
    }
}
