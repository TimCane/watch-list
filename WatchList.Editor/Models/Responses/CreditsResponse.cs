namespace WatchList.Editor.Models.Responses;

public class CreditsResponse : PagedResponse
{
    public List<Credit> Credits { get; set; }
}