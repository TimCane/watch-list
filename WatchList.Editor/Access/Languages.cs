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
    public class Languages : ILanguages
    {
        private readonly IMapper _mapper;
        private readonly ILanguageRepository _languageRepository;

        public Languages(IMapper mapper, ILanguageRepository languageRepository)
        {
            _mapper = mapper;
            _languageRepository = languageRepository;
        }

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new OrderBy<DbLanguage,Guid>(x => x.Id) },
                { "Iso", new OrderBy<DbLanguage,string>(x => x.Iso) },
                { "Name", new OrderBy<DbLanguage,string>(x => x.Name) },
                { "CreatedOn", new OrderBy<DbLanguage,DateTime>(x => x.CreatedOn) },
                { "ModifiedOn", new OrderBy<DbLanguage,DateTime>(x => x.ModifiedOn) },
                { "CreatedBy", new OrderBy<DbLanguage,Guid>(x => x.CreatedBy) },
                { "ModifiedBy", new OrderBy<DbLanguage,Guid>(x => x.ModifiedBy) },
            };

        public async Task<LanguagesResponse> Get(User user, PagedRequest request)
        {
            Expression<Func<DbLanguage, bool>>? expr = null;
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

            var (languages, total) = await _languageRepository.GetAll(expr, request.Skip, request.Take, sort, (int)request.SortOrder);

            return new LanguagesResponse()
            {
                Total = total,
                Search = request.Search,
                Skip = request.Skip,
                SortField = request.SortField,
                SortOrder = request.SortOrder,
                Take = request.Take,
                Languages = _mapper.Map<List<Language>>(languages)
            };
        }

        public async Task<LanguageResponse> Get(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var language = await _languageRepository.GetById(id);

            return new LanguageResponse(_mapper.Map<Language>(language));
        }

        public async Task<CreateLanguageResponse> Create(User user, CreateLanguageRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var language = _mapper.Map<DbLanguage>(request);

            await _languageRepository.Add(language);

            return new CreateLanguageResponse(_mapper.Map<Language>(language));
        }

        public async Task<UpdateLanguageResponse> Update(User user, Guid id, UpdateLanguageRequest request)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var existingLanguage = await _languageRepository.GetById(id);
            if (existingLanguage == null)
            {
                throw new HttpBadRequestException($"Language with Id: '{id}' doesn't exist");
            }

            existingLanguage.Name = !string.IsNullOrWhiteSpace(request.Name) ? request.Name : existingLanguage.Name;

            await _languageRepository.Update(existingLanguage);

            return new UpdateLanguageResponse(_mapper.Map<Language>(existingLanguage));
        }

        public async Task<DeleteLanguageResponse> Delete(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var existingLanguage = await _languageRepository.GetById(id);
            if (existingLanguage == null)
            {
                return new DeleteLanguageResponse(false);
            }

            await _languageRepository.Remove(existingLanguage);

            return new DeleteLanguageResponse(true);
        }
    }
}
