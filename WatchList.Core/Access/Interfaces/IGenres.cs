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
    public interface IGenres
    {
        Task<GenresResponse> Get(User user);

        Task<GenreResponse> Get(User user, Guid id);

        Task<CreateGenreResponse> Create(User user, CreateGenreRequest request);

        Task<UpdateGenreResponse> Update(User user, Guid id, UpdateGenreRequest request);

        Task<DeleteGenreResponse> Delete(User user, Guid id);
    }
}
