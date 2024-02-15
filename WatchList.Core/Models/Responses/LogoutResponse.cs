using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses
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
