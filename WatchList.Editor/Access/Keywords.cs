using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Exceptions;
using WatchList.Core.Interfaces;
using WatchList.Core.Models;
using WatchList.Editor.Access.Interfaces;
using WatchList.Editor.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;
using WatchList.Editor.Repositories.Interfaces;

namespace WatchList.Editor.Access
{
    public class Keywords : IKeywords
    {
        private readonly IMapper _mapper;
        private readonly IKeywordRepository _keywordRepository;

        public Keywords(IMapper mapper, IKeywordRepository keywordRepository)
        {
            _mapper = mapper;
            _keywordRepository = keywordRepository;
        }

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new OrderBy<DbKeyword,Guid>(x => x.Id) },
                { "Name", new OrderBy<DbKeyword,string>(x => x.Name) },
                { "CreatedOn", new OrderBy<DbKeyword,DateTime>(x => x.CreatedOn) },
                { "ModifiedOn", new OrderBy<DbKeyword,DateTime>(x => x.ModifiedOn) },
                { "CreatedBy", new OrderBy<DbKeyword,Guid>(x => x.CreatedBy) },
                { "ModifiedBy", new OrderBy<DbKeyword,Guid>(x => x.ModifiedBy) },
            };

        public async Task<KeywordsResponse> Get(User user, PagedRequest request)
        {
            Expression<Func<DbKeyword, bool>>? expr = null;
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

            var (keywords, total) = await _keywordRepository.GetAll(expr, request.Skip, request.Take, sort, (int)request.SortOrder);

            return new KeywordsResponse()
            {
                Total = total,
                Search = request.Search,
                Skip = request.Skip,
                SortField = request.SortField,
                SortOrder = request.SortOrder,
                Take = request.Take,
                Keywords = _mapper.Map<List<Keyword>>(keywords)
            };
        }

        public async Task<KeywordResponse> Get(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var keyword = await _keywordRepository.GetById(id);

            return new KeywordResponse(_mapper.Map<Keyword>(keyword));
        }

        public async Task<CreateKeywordResponse> Create(User user, CreateKeywordRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var keyword = _mapper.Map<DbKeyword>(request);

            await _keywordRepository.Add(keyword);

            return new CreateKeywordResponse(_mapper.Map<Keyword>(keyword));
        }

        public async Task<UpdateKeywordResponse> Update(User user, Guid id, UpdateKeywordRequest request)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var existingKeyword = await _keywordRepository.GetById(id);
            if (existingKeyword == null)
            {
                throw new HttpBadRequestException($"Keyword with Id: '{id}' doesn't exist");
            }

            existingKeyword.Name = !string.IsNullOrWhiteSpace(request.Name) ? request.Name : existingKeyword.Name;

            await _keywordRepository.Update(existingKeyword);

            return new UpdateKeywordResponse(_mapper.Map<Keyword>(existingKeyword));
        }

        public async Task<DeleteKeywordResponse> Delete(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var existingKeyword = await _keywordRepository.GetById(id);
            if (existingKeyword == null)
            {
                return new DeleteKeywordResponse(false);
            }

            await _keywordRepository.Remove(existingKeyword);

            return new DeleteKeywordResponse(true);
        }
    }
}
