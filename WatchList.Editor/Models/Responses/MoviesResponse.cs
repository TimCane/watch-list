namespace WatchList.Editor.Models.Responses;

public class MoviesResponse : PagedResponse
{
    public List<Movie> Movies { get; set; }
}