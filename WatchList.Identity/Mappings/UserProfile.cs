using AutoMapper;
using WatchList.Core.Entities.Identity;
using WatchList.Core.Models;

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
