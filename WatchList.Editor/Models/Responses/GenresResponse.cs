namespace WatchList.Editor.Models.Responses;

public class GenresResponse : PagedResponse
{
    public List<Genre> Genres { get; set; }
}