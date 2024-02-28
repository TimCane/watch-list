using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses;

public class ResetPasswordResponse : IResponse
{
    public ResetPasswordResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}