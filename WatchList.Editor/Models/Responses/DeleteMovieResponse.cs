using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class DeleteMovieResponse : IResponse
{
    public bool Success { get; set; }

    public DeleteMovieResponse(bool success)
    {
        Success = success;
    }
}