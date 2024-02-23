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
    public class Genres : IGenres
    {
        private readonly IMapper _mapper;
        private readonly IGenreRepository _genreRepository;

        public Genres(IMapper mapper, IGenreRepository genreRepository)
        {
            _mapper = mapper;
            _genreRepository = genreRepository;
        }

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new OrderBy<DbGenre,Guid>(x => x.Id) },
            };

        public async Task<GenresResponse> Get(User user, PagedRequest request)
        {
            Expression<Func<DbGenre, bool>>? expr = null;
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

            var (genres, total) = await _genreRepository.GetAll(expr, request.Skip, request.Take, sort, (int)request.SortOrder);

            return new GenresResponse()
            {
                Total = total,
                Search = request.Search,
                Skip = request.Skip,
                SortField = request.SortField,
                SortOrder = request.SortOrder,
                Take = request.Take,
                Genres = _mapper.Map<List<Genre>>(genres)
            };
        }

        public async Task<GenreResponse> Get(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var genre = await _genreRepository.GetById(id);

            return new GenreResponse(_mapper.Map<Genre>(genre));
        }

        public async Task<CreateGenreResponse> Create(User user, CreateGenreRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var genre = _mapper.Map<DbGenre>(request);

            await _genreRepository.Add(genre);

            return new CreateGenreResponse(_mapper.Map<Genre>(genre));
        }

        public async Task<UpdateGenreResponse> Update(User user, Guid id, UpdateGenreRequest request)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var existingGenre = await _genreRepository.GetById(id);
            if (existingGenre == null)
            {
                throw new HttpBadRequestException($"Genre with Id: '{id}' doesn't exist");
            }

            existingGenre.Name = !string.IsNullOrWhiteSpace(request.Name) ? request.Name : existingGenre.Name;

            await _genreRepository.Update(existingGenre);

            return new UpdateGenreResponse(_mapper.Map<Genre>(existingGenre));
        }

        public async Task<DeleteGenreResponse> Delete(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var existingGenre = await _genreRepository.GetById(id);
            if (existingGenre == null)
            {
                return new DeleteGenreResponse(false);
            }

            await _genreRepository.Remove(existingGenre);

            return new DeleteGenreResponse(true);
        }
    }
}
