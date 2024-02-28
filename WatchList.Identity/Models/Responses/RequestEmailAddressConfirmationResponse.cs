using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses
{
    public class RequestEmailAddressConfirmationResponse : IResponse
    {
        public RequestEmailAddressConfirmationResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
    }
}
