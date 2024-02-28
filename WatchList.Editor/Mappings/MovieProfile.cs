using AutoMapper;
using WatchList.Core.Entities.Editor;
using WatchList.Editor.Models;

namespace WatchList.Editor.Mappings
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<DbMovie, Movie>();
        }
    }
}
