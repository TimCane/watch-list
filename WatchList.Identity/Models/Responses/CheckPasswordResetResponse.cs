using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses;

public class CheckPasswordResetResponse : IResponse
{
    public CheckPasswordResetResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}