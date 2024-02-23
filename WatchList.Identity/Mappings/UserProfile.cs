using AutoMapper;
using WatchList.Core.Models;
using WatchList.Identity.Entities;

namespace WatchList.Identity.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<DbUser, User>();
        }
    }
}
