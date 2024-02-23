using AutoMapper;
using WatchList.Editor.Entities;
using WatchList.Editor.Models;

namespace WatchList.Editor.Mappings
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            CreateMap<DbGenre, Genre>();
        }
    }
}
