namespace WatchList.Editor.Models.Responses;

public class ProductionCountriesResponse : PagedResponse
{
    public List<ProductionCountry> ProductionCountries { get; set; }
}