using AutoMapper;
using WatchList.Core.Entities.Editor;
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
