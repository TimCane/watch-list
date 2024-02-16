using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Access.Interfaces;
using WatchList.Core.Data.Repositories.Interfaces;
using WatchList.Core.Models;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;

namespace WatchList.Core.Access
{
    public class Collections : ICollections
    {
        private readonly IMapper _mapper;
        private readonly ICollectionRepository _collectionRepository;

        public Collections(IMapper mapper, ICollectionRepository collectionRepository)
        {
            _mapper = mapper;
            _collectionRepository = collectionRepository;
        }

        public async Task<CollectionsResponse> Get(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<CollectionResponse> Get(User user, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateCollectionResponse> Create(User user, CreateCollectionRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateCollectionResponse> Update(User user, Guid id, UpdateCollectionRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteCollectionResponse> Delete(User user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
