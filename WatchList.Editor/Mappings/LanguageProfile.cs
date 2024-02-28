using AutoMapper;
using WatchList.Core.Entities.Editor;
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
