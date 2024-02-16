using AutoMapper;
using WatchList.Core.Data.Entities;
using WatchList.Core.Models;

namespace WatchList.Core.Mappings
{
    public class ProductionCountryProfile : Profile
    {
        public ProductionCountryProfile()
        {
            CreateMap<DbProductionCountry, ProductionCountry>();
        }
    }
}
