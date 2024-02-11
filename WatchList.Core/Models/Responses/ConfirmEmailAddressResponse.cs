using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses;

public class ConfirmEmailAddressResponse : IResponse
{
    public ConfirmEmailAddressResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}