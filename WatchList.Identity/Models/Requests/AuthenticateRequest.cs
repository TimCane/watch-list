using System.ComponentModel.DataAnnotations;
using WatchList.Core.Constants;
using WatchList.Core.Models.Interfaces;
using WatchList.Core.Swagger;

namespace WatchList.Identity.Models.Requests;

public class AuthenticateRequest : IRequest
{
    [Example(ExampleConstants.EmailAddress)]
    [Required]
    public string? EmailAddress { get; set; }

    [Example(ExampleConstants.Password)]
    [Required]
    public string? Password { get; set; }
}