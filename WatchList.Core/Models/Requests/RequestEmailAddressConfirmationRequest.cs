using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Constants;
using WatchList.Core.Models.Requests.Interfaces;
using WatchList.Core.Swagger;

namespace WatchList.Core.Models.Requests
{
    public class RequestEmailAddressConfirmationRequest : IRequest
    {
        [Example(ExampleConstants.EmailAddress)]
        [Required]
        public string? EmailAddress { get; set; }
    }
}
