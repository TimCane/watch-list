using AutoMapper;
using WatchList.Editor.Entities;
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
