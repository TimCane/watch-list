using AutoMapper;
using WatchList.Core.Data.Entities;
using WatchList.Core.Models;

namespace WatchList.Core.Mappings
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<DbLanguage, Language>();
        }
    }
}
