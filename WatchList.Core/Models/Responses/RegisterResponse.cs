using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses;

public class RegisterResponse : IResponse
{
    public RegisterResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}