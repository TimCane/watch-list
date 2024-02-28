using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class DeleteKeywordResponse : IResponse
{
    public bool Success { get; set; }

    public DeleteKeywordResponse(bool success)
    {
        Success = success;
    }
}