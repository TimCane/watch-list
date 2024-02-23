using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class ProductionCompanyResponse : IResponse
{
    public ProductionCompany ProductionCompany { get; set; }

    public ProductionCompanyResponse(ProductionCompany productionCompany)
    {
        ProductionCompany = productionCompany;
    }
}