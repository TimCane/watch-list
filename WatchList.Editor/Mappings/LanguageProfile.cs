using AutoMapper;
using WatchList.Editor.Entities;
using WatchList.Editor.Models;

namespace WatchList.Editor.Mappings
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<DbLanguage, Language>();
        }
    }
}
