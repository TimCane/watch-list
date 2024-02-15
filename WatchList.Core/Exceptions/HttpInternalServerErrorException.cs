using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
