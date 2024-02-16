using AutoMapper;
using WatchList.Core.Data.Entities;
using WatchList.Core.Models;

namespace WatchList.Core.Mappings
{
    public class KeywordProfile : Profile
    {
        public KeywordProfile()
        {
            CreateMap<DbKeyword, Keyword>();
        }
    }
}
