using WatchList.Core.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;

namespace WatchList.Editor.Access.Interfaces
{
    public interface IMovies
    {
        Task<MoviesResponse> Get(User user, PagedRequest request);

        Task<MovieResponse> Get(User user, Guid id);

        Task<CreateMovieResponse> Create(User user, CreateMovieRequest request);

        Task<UpdateMovieResponse> Update(User user, Guid id, UpdateMovieRequest request);

        Task<DeleteMovieResponse> Delete(User user, Guid id);
    }
}
