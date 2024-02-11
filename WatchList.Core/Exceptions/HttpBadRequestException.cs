namespace WatchList.Core.Exceptions
{
    public class HttpBadRequestException : Exception
    {
        /*public HttpBadRequestException(): this("BadBadRequestRequest")
        {
        }*/
        public HttpBadRequestException(string? message) : base(message)
        {
        }
    }
}
