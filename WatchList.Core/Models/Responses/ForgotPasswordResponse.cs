using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses;

public class ForgotPasswordResponse : IResponse
{
    public ForgotPasswordResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}