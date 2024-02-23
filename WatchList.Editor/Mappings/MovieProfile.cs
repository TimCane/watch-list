using AutoMapper;
using WatchList.Editor.Entities;
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
