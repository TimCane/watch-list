using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Requests;

public class UpdateCollectionRequest : IRequest
{
    public string Name { get; set; }
}