namespace WatchList.Core.Exceptions
{
    public class HttpUnauthorizedException : Exception
    {
        public HttpUnauthorizedException() : this("Unauthorized")
        {
        }

        public HttpUnauthorizedException(string message) : base(message)
        {

        }
    }
}
