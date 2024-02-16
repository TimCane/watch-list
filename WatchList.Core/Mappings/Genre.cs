using AutoMapper;
using WatchList.Core.Data.Entities;
using WatchList.Core.Models;

namespace WatchList.Core.Mappings
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<DbGenre, Genre>();
        }
    }
}
