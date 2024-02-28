using AutoMapper;
using WatchList.Core.Entities.Editor;
using WatchList.Editor.Models;

namespace WatchList.Editor.Mappings
{
    public class ProductionCountryProfile : Profile
    {
        public ProductionCountryProfile()
        {
            CreateMap<DbProductionCountry, ProductionCountry>();
        }
    }
}
