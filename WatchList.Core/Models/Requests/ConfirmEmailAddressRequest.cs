﻿using System.ComponentModel.DataAnnotations;
using WatchList.Core.Models.Requests.Interfaces;

namespace WatchList.Core.Models.Requests;

public class ConfirmEmailAddressRequest : IRequest
{
    [Required]
    public Guid UserPromptId { get; set; }
}