using AutoMapper;
using WatchList.Core.Entities.Editor;
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
