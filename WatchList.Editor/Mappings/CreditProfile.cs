using AutoMapper;
using WatchList.Editor.Entities;
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
