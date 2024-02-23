using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchList.Core.Exceptions;
using WatchList.Core.Interfaces;
using WatchList.Core.Models;
using WatchList.Editor.Access.Interfaces;
using WatchList.Editor.Entities;
using WatchList.Editor.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Access
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

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new OrderBy<DbCollection,Guid>(x => x.Id) },
                { "Name", new OrderBy<DbCollection,string>(x => x.Name) },
                { "CreatedOn", new OrderBy<DbCollection,DateTime>(x => x.CreatedOn) },
                { "ModifiedOn", new OrderBy<DbCollection,DateTime>(x => x.ModifiedOn) },
            };
        
        public async Task<CollectionsResponse> Get(User user, PagedRequest request)
        {
            Expression<Func<DbCollection, bool>>? expr = null;
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                expr = x =>
                    EF.Functions.Like(x.Name, $"%{request.Search}%");
            }

            IOrderBy? sort = null;
            if (!string.IsNullOrWhiteSpace(request.SortField) && OrderFunctions.ContainsKey(request.SortField))
            {
                sort = OrderFunctions[request.SortField];
            }

            var (collections, total) = await _collectionRepository.GetAll(expr, request.Skip, request.Take, sort, (int)request.SortOrder);
            
            return new CollectionsResponse()
            {
                Total = total,
                Search = request.Search,
                Skip = request.Skip,
                SortField = request.SortField,
                SortOrder = request.SortOrder,
                Take = request.Take,
                Collections = _mapper.Map<List<Collection>>(collections)
            };
        }

        public async Task<CollectionResponse> Get(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var collection = await _collectionRepository.GetById(id);

            return new CollectionResponse(_mapper.Map<Collection>(collection));
        }

        public async Task<CreateCollectionResponse> Create(User user, CreateCollectionRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var collection = _mapper.Map<DbCollection>(request);

            await _collectionRepository.Add(collection);

            return new CreateCollectionResponse(_mapper.Map<Collection>(collection));
        }

        public async Task<UpdateCollectionResponse> Update(User user, Guid id, UpdateCollectionRequest request)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var existingCollection = await _collectionRepository.GetById(id);
            if (existingCollection == null)
            {
                throw new HttpBadRequestException($"Collection with Id: '{id}' doesn't exist");
            }

            existingCollection.Name = !string.IsNullOrWhiteSpace(request.Name) ? request.Name : existingCollection.Name;

            await _collectionRepository.Update(existingCollection);

            return new UpdateCollectionResponse(_mapper.Map<Collection>(existingCollection));
        }

        public async Task<DeleteCollectionResponse> Delete(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var existingCollection = await _collectionRepository.GetById(id);
            if (existingCollection == null)
            {
                return new DeleteCollectionResponse(false);
            }

            await _collectionRepository.Remove(existingCollection);

            return new DeleteCollectionResponse(true);
        }
    }
}
