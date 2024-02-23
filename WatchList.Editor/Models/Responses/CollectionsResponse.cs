namespace WatchList.Editor.Models.Responses;

public class CollectionsResponse : PagedResponse
{
    public List<Collection> Collections { get; set; }
}