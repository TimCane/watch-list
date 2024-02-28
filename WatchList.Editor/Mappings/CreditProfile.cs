using AutoMapper;
using WatchList.Core.Entities.Editor;
using WatchList.Editor.Models;

namespace WatchList.Editor.Mappings
{
    public class CreditProfile : Profile
    {
        public CreditProfile()
        {
            CreateMap<DbCredit, Credit>();
        }
    }
}
