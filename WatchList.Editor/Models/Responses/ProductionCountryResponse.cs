using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class ProductionCountryResponse : IResponse
{
    public ProductionCountry ProductionCountry { get; set; }

    public ProductionCountryResponse(ProductionCountry productionCountry)
    {
        ProductionCountry = productionCountry;
    }
}