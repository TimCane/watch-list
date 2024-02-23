using System.ComponentModel.DataAnnotations;
using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Requests;

public class CheckPasswordResetRequest : IRequest
{
    [Required]
    public Guid UserPromptId { get; set; }
}