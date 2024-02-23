using AutoMapper;
using WatchList.Editor.Entities;
using WatchList.Editor.Models;

namespace WatchList.Editor.Mappings
{
    public class ProductionCompanyProfile : Profile
    {
        public ProductionCompanyProfile()
        {
            CreateMap<DbProductionCompany, ProductionCompany>();
        }
    }
}
