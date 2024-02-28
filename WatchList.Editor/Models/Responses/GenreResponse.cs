using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class GenreResponse : IResponse
{
    public Genre Genre { get; set; }

    public GenreResponse(Genre genre)
    {
        Genre = genre;
    }
}