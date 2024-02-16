using AutoMapper;
using WatchList.Core.Data.Entities;
using WatchList.Core.Models;

namespace WatchList.Core.Mappings
{
    public class ProductionCompanyProfile : Profile
    {
        public ProductionCompanyProfile()
        {
            CreateMap<DbProductionCompany, ProductionCompany>();
        }
    }
}
