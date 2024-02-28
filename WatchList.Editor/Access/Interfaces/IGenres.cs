using WatchList.Core.Models;
using WatchList.Editor.Models.Requests;
using WatchList.Editor.Models.Responses;

namespace WatchList.Editor.Access.Interfaces
{
    public interface IGenres
    {
        Task<GenresResponse> Get(User user, PagedRequest request);

        Task<GenreResponse> Get(User user, Guid id);

        Task<CreateGenreResponse> Create(User user, CreateGenreRequest request);

        Task<UpdateGenreResponse> Update(User user, Guid id, UpdateGenreRequest request);

        Task<DeleteGenreResponse> Delete(User user, Guid id);
    }
}
