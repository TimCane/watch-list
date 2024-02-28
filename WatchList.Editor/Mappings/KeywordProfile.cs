using AutoMapper;
using WatchList.Core.Entities.Editor;
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
