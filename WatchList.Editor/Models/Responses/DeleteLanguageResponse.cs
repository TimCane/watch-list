using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class DeleteLanguageResponse : IResponse
{
    public bool Success { get; set; }

    public DeleteLanguageResponse(bool success)
    {
        Success = success;
    }
}