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
    public interface IMovies
    {
        Task<MoviesResponse> Get(User user);

        Task<MovieResponse> Get(User user, Guid id);

        Task<CreateMovieResponse> Create(User user, CreateMovieRequest request);

        Task<UpdateMovieResponse> Update(User user, Guid id, UpdateMovieRequest request);

        Task<DeleteMovieResponse> Delete(User user, Guid id);
    }
}
