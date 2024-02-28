namespace WatchList.Editor.Models.Responses;

public class ProductionCompaniesResponse : PagedResponse
{
    public List<ProductionCompany> ProductionCompanies { get; set; }
}