using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Requests;

public class UpdateProductionCompanyRequest : IRequest
{
    public string Name { get; set; }
}