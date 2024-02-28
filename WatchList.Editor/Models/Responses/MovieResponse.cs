using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class MovieResponse : IResponse
{
    public Movie Movie { get; set; }

    public MovieResponse(Movie movie)
    {
        Movie = movie;
    }
}