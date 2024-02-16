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
    public class Movies : IMovies
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public Movies(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<MoviesResponse> Get(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<MovieResponse> Get(User user, Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateMovieResponse> Create(User user, CreateMovieRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<UpdateMovieResponse> Update(User user, Guid id, UpdateMovieRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<DeleteMovieResponse> Delete(User user, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
