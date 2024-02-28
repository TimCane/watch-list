using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses;

public class ConfirmEmailAddressResponse : IResponse
{
    public ConfirmEmailAddressResponse(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }
}