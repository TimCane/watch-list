using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses;

public class AuthenticateResponse : IResponse
{
    public AuthenticateResponse(string bearerToken, string refreshToken)
    {
        BearerToken = bearerToken;
        RefreshToken = refreshToken;
    }

    public string BearerToken { get; }

    public string RefreshToken { get; }
}