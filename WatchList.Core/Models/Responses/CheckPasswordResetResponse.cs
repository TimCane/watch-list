using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses;

public class CheckPasswordResetResponse : IResponse
{
    public CheckPasswordResetResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}