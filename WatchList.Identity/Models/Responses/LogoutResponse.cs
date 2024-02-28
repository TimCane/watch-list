using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Responses
{
    public class LogoutResponse : IResponse
    {
        public LogoutResponse(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
    }
}
