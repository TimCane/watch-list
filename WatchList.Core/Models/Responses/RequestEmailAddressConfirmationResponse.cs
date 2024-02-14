using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses
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
