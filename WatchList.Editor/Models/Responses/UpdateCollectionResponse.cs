using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class UpdateCollectionResponse : IResponse
{
    public Collection Collection { get; set; }
    public UpdateCollectionResponse(Collection collection)
    {
        Collection = collection;
    }
}