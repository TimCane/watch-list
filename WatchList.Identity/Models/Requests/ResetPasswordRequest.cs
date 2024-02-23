using System.ComponentModel.DataAnnotations;
using WatchList.Core.Constants;
using WatchList.Core.Models.Interfaces;
using WatchList.Core.Swagger;

namespace WatchList.Identity.Models.Requests;

public class ResetPasswordRequest : IRequest
{

    [Required]
    public Guid UserPromptId { get; set; }

    [Example(ExampleConstants.Password)]
    [Required]
    public string? NewPassword { get; set; }
}