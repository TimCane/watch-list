using AutoMapper;
using System.Linq.Expressions;
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
    public class Movies : IMovies
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public Movies(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        private static readonly Dictionary<string, IOrderBy> OrderFunctions =
            new(StringComparer.OrdinalIgnoreCase)
            {
                { "Id", new OrderBy<DbMovie,Guid>(x => x.Id) },
                { "Adult", new OrderBy<DbMovie,bool?>(x => x.Adult) },
                { "Budget", new OrderBy<DbMovie,int?>(x => x.Budget) },
                { "Homepage", new OrderBy<DbMovie,string?>(x => x.Homepage) },
                { "OriginalTitle", new OrderBy<DbMovie, string?>(x => x.OriginalTitle) },
                { "Overview", new OrderBy<DbMovie, string?>(x => x.Overview) },
                { "ReleaseDate", new OrderBy<DbMovie, DateTime?>(x => x.ReleaseDate) },
                { "Revenue", new OrderBy<DbMovie, long?>(x => x.Revenue) },
                { "Runtime", new OrderBy<DbMovie, int?>(x => x.Runtime) },
                { "TagLine", new OrderBy<DbMovie, string?>(x => x.TagLine) },
                { "Title", new OrderBy<DbMovie, string?>(x => x.Title) },
                { "CreatedOn", new OrderBy<DbMovie, DateTime>(x => x.CreatedOn) },
                { "CreatedBy", new OrderBy<DbMovie, Guid>(x => x.CreatedBy) },
                { "ModifiedOn", new OrderBy<DbMovie, DateTime>(x => x.ModifiedOn) },
                { "ModifiedBy", new OrderBy<DbMovie, Guid>(x => x.ModifiedBy) },
            };

        public async Task<MoviesResponse> Get(User user, PagedRequest request)
        {
            Expression<Func<DbMovie, bool>>? expr = null;
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                expr = x =>
                    EF.Functions.Like(x.Title, $"%{request.Search}%");
            }

            IOrderBy? sort = null;
            if (!string.IsNullOrWhiteSpace(request.SortField) && OrderFunctions.ContainsKey(request.SortField))
            {
                sort = OrderFunctions[request.SortField];
            }

            var (movies, total) = await _movieRepository.GetAll(expr, request.Skip, request.Take, sort, (int)request.SortOrder);

            return new MoviesResponse()
            {
                Total = total,
                Search = request.Search,
                Skip = request.Skip,
                SortField = request.SortField,
                SortOrder = request.SortOrder,
                Take = request.Take,
                Movies = _mapper.Map<List<Movie>>(movies)
            };
        }

        public async Task<MovieResponse> Get(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var movie = await _movieRepository.GetById(id);

            return new MovieResponse(_mapper.Map<Movie>(movie));
        }

        public async Task<CreateMovieResponse> Create(User user, CreateMovieRequest request)
        {
            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var movie = _mapper.Map<DbMovie>(request);

            await _movieRepository.Add(movie);

            return new CreateMovieResponse(_mapper.Map<Movie>(movie));
        }

        public async Task<UpdateMovieResponse> Update(User user, Guid id, UpdateMovieRequest request)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            if (request == null)
            {
                throw new HttpBadRequestException($"{nameof(request)} is null");
            }

            var existingMovie = await _movieRepository.GetById(id);
            if (existingMovie == null)
            {
                throw new HttpBadRequestException($"Movie with Id: '{id}' doesn't exist");
            }

            existingMovie.Title = !string.IsNullOrWhiteSpace(request.Title) ? request.Title : existingMovie.Title;

            await _movieRepository.Update(existingMovie);

            return new UpdateMovieResponse(_mapper.Map<Movie>(existingMovie));
        }

        public async Task<DeleteMovieResponse> Delete(User user, Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new HttpBadRequestException($"{nameof(id)} is null");
            }

            var existingMovie = await _movieRepository.GetById(id);
            if (existingMovie == null)
            {
                return new DeleteMovieResponse(false);
            }

            await _movieRepository.Remove(existingMovie);

            return new DeleteMovieResponse(true);
        }
    }
}
