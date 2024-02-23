using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Requests;

public class UpdateProductionCountryRequest : IRequest
{
    public string Iso { get; set; }
    public string Name { get; set; }
}