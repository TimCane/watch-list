using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses;

public class WhoAmIResponse : IResponse
{
    public WhoAmIResponse(User user)
    {
        User = user;
    }

    public User User { get; set; }
}