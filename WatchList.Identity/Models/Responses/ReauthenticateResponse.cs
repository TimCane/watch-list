using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses;

public class ReauthenticateResponse : IResponse
{
    public ReauthenticateResponse(string bearerToken, string refreshToken)
    {
        BearerToken = bearerToken;
        RefreshToken = refreshToken;
    }

    public string BearerToken { get; }
    public string RefreshToken { get; }
}