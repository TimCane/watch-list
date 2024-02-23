using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class DeleteCollectionResponse : IResponse
{
    public bool Success { get; set; }

    public DeleteCollectionResponse(bool success)
    {
        Success = success;
    }
}