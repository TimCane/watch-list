using System.ComponentModel.DataAnnotations;
using WatchList.Core.Constants;
using WatchList.Core.Models.Interfaces;
using WatchList.Core.Swagger;

namespace WatchList.Identity.Models.Requests;

public class ReauthenticateRequest : IRequest
{
    [Example(ExampleConstants.RefreshToken)]
    [Required]
    public string? RefreshToken { get; set; }
}