using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CreateCollectionResponse : IResponse
{
    public Collection Collection { get; set; }
    public CreateCollectionResponse(Collection collection)
    {
        Collection = collection;
    }
}