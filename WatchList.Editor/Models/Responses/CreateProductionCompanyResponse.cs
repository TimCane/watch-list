using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CreateProductionCompanyResponse : IResponse
{
    public ProductionCompany ProductionCompany { get; set; }

    public CreateProductionCompanyResponse(ProductionCompany productionCompany)
    {
        ProductionCompany = productionCompany;
    }
}