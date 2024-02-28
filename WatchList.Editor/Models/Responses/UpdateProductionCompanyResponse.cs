using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class UpdateProductionCompanyResponse : IResponse
{
    public ProductionCompany ProductionCompany { get; set; }

    public UpdateProductionCompanyResponse(ProductionCompany productionCompany)
    {
        ProductionCompany = productionCompany;
    }
}