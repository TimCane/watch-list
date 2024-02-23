using AutoMapper;
using WatchList.Editor.Entities;
using WatchList.Editor.Models;

namespace WatchList.Editor.Mappings
{
    public class KeywordProfile : Profile
    {
        public KeywordProfile()
        {
            CreateMap<DbKeyword, Keyword>();
        }
    }
}
