using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses;

public class ResetPasswordResponse : IResponse
{
    public ResetPasswordResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}