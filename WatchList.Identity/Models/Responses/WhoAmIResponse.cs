using WatchList.Core.Models;
using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses;

public class WhoAmIResponse : IResponse
{
    public WhoAmIResponse(User user)
    {
        User = user;
    }

    public User User { get; set; }
}