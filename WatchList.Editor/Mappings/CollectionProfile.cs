using AutoMapper;
using WatchList.Core.Entities.Editor;
using WatchList.Editor.Models;
using WatchList.Editor.Models.Requests;

namespace WatchList.Editor.Mappings
{
    public class CollectionProfile : Profile
    {
        public CollectionProfile()
        {
            CreateMap<DbCollection, Collection>();
            CreateMap<Collection, DbCollection>();

            CreateMap<CreateCollectionRequest, DbCollection>();
            CreateMap<DbCollection, CreateCollectionRequest>();

            CreateMap<UpdateCollectionRequest, DbCollection>();
            CreateMap<DbCollection, UpdateCollectionRequest>();
        }
    }
}
