using System.ComponentModel.DataAnnotations;
using WatchList.Core.Constants;
using WatchList.Core.Models.Interfaces;
using WatchList.Core.Swagger;

namespace WatchList.Identity.Models.Requests;

public class RegisterRequest : IRequest
{
    [Example(ExampleConstants.EmailAddress)]
    [Required]
    public string? EmailAddress { get; set; }

    [Example(ExampleConstants.Name)]
    [Required]
    public string? Name { get; set; }

    [Example(ExampleConstants.Password)]
    [Required]
    public string? Password { get; set; }
}