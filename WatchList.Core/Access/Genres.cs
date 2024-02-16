using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Access.Interfaces;
using WatchList.Core.Data.Repositories.Interfaces;
using WatchList.Core.Models;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses;

namespace WatchList.Core.Access
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

        public async Task<GenresResponse> Get(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<GenreResponse> Get(User user, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateGenreResponse> Create(User user, CreateGenreRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateGenreResponse> Update(User user, Guid id, UpdateGenreRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteGenreResponse> Delete(User user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
