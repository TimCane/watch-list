using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class UpdateProductionCountryResponse : IResponse
{
    public ProductionCountry ProductionCountry { get; set; }

    public UpdateProductionCountryResponse(ProductionCountry productionCountry)
    {
        ProductionCountry = productionCountry;
    }
}