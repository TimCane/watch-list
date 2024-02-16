using AutoMapper;
using WatchList.Core.Data.Entities;
using WatchList.Core.Models;

namespace WatchList.Core.Mappings
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<DbCollection, Collection>();
        }
    }
}
