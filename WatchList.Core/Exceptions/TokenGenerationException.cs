namespace WatchList.Core.Exceptions
{
    public class TokenGenerationException : Exception
    {
        public TokenGenerationException() : this("Problem generating token")
        {
        }

        public TokenGenerationException(string message) : base(message)
        {

        }
    }
}
