using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class UpdateMovieResponse : IResponse
{
    public Movie Movie { get; set; }

    public UpdateMovieResponse(Movie movie)
    {
        Movie = movie;
    }
}