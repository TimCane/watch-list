using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Requests;

public class CreateCollectionRequest : IRequest
{
    public string Name { get; set; }
}