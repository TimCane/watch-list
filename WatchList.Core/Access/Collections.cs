using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WatchList.Core.Access.Interfaces;
using WatchList.Core.Data.Entities;
using WatchList.Core.Data.Repositories.Interfaces;
using WatchList.Core.Interfaces;
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

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new OrderBy<DbCollection,Guid>(x => x.Id) },
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
