using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CollectionResponse : IResponse
{
    public Collection Collection { get; set; }
    public CollectionResponse(Collection collection)
    {
        Collection = collection;
    }
}