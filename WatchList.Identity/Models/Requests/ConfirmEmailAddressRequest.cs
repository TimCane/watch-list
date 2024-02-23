using System.ComponentModel.DataAnnotations;
using WatchList.Core.Models.Interfaces;

namespace WatchList.Identity.Models.Requests;

public class ConfirmEmailAddressRequest : IRequest
{
    [Required]
    public Guid UserPromptId { get; set; }
}