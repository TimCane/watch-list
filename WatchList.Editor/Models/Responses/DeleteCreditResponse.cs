using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class DeleteCreditResponse : IResponse
{
    public bool Success { get; set; }
    public DeleteCreditResponse(bool success)
    {
        Success = success;
    }
}