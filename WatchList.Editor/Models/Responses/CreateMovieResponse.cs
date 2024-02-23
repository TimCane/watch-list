using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CreateMovieResponse : IResponse
{
    public Movie Movie { get; set; }

    public CreateMovieResponse(Movie movie)
    {
        Movie = movie;
    }
}