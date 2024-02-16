using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Models;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;

namespace WatchList.Core.Access.Interfaces
{
    public interface ICollections
    {
        Task<CollectionsResponse> Get(User user);

        Task<CollectionResponse> Get(User user, Guid id);

        Task<CreateCollectionResponse> Create(User user, CreateCollectionRequest request);

        Task<UpdateCollectionResponse> Update(User user, Guid id, UpdateCollectionRequest request);

        Task<DeleteCollectionResponse> Delete(User user, Guid id);
    }
}
