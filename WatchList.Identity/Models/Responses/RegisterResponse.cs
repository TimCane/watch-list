using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses;

public class RegisterResponse : IResponse
{
    public RegisterResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}