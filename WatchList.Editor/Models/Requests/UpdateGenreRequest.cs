using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Requests;

public class UpdateGenreRequest : IRequest
{
    public string Name { get; set; }
}