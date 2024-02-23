using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CreateProductionCountryResponse : IResponse
{
    public ProductionCountry ProductionCountry { get; set; }

    public CreateProductionCountryResponse(ProductionCountry productionCountry)
    {
        ProductionCountry = productionCountry;
    }
}