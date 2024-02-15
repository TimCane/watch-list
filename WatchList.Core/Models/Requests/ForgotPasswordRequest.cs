using System.ComponentModel.DataAnnotations;
using WatchList.Core.Constants;
using WatchList.Core.Models.Requests.Interfaces;
using WatchList.Core.Swagger;

namespace WatchList.Core.Models.Requests;

public class ForgotPasswordRequest : IRequest
{
    [Example(ExampleConstants.EmailAddress)]
    [Required]
    public string? EmailAddress { get; set; }
}