using AutoMapper;
using WatchList.Core.Data.Entities;
using WatchList.Core.Models;

namespace WatchList.Core.Mappings
{
    public class CreditProfile : Profile
    {
        public CreditProfile()
        {
            CreateMap<DbCredit, Credit>();
        }
    }
}
