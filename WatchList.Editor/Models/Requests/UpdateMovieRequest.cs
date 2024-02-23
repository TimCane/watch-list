using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Requests;

public class UpdateMovieRequest : IRequest
{
    public string Title { get; set; }

    public string Overview { get; set; }

    public DateTime ReleaseDate { get; set; }

    public int Runtime { get; set; }
}