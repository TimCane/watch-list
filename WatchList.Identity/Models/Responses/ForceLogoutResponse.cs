using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses
{
    public class ForceLogoutResponse : IResponse
    {
        public ForceLogoutResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
    }
}
