using AutoMapper;
using WatchList.Editor.Entities;
using WatchList.Editor.Models;

namespace WatchList.Editor.Mappings
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<DbCollection, Collection>();
        }
    }
}
