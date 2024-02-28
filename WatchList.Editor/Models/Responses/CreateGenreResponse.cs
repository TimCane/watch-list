using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CreateGenreResponse : IResponse
{
    public Genre Genre { get; set; }

    public CreateGenreResponse(Genre genre)
    {
        Genre = genre;
    }
}