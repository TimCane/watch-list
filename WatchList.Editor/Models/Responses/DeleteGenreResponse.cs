using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class DeleteGenreResponse : IResponse
{
    public bool Success { get; set; }

    public DeleteGenreResponse(bool success)
    {
        Success = success;
    }
}