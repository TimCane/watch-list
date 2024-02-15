using System.ComponentModel.DataAnnotations;
using WatchList.Core.Constants;
using WatchList.Core.Models.Requests.Interfaces;
using WatchList.Core.Swagger;

namespace WatchList.Core.Models.Requests;

public class ReauthenticateRequest : IRequest
{
    [Example(ExampleConstants.RefreshToken)]
    [Required]
    public string? RefreshToken { get; set; }
}