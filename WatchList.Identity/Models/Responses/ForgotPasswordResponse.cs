using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses;

public class ForgotPasswordResponse : IResponse
{
    public ForgotPasswordResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}