namespace WatchList.Core.Exceptions
{
    public class HttpInternalServerErrorException : Exception
    {
        public HttpInternalServerErrorException() : this("Internal Server Error")
        {
        }

        public HttpInternalServerErrorException(string message) : base(message)
        {

        }
    }
}
