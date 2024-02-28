using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class UpdateGenreResponse : IResponse
{
    public Genre Genre { get; set; }

    public UpdateGenreResponse(Genre genre)
    {
        Genre = genre;
    }
}