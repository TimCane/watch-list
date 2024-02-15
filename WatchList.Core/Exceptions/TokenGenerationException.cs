using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
