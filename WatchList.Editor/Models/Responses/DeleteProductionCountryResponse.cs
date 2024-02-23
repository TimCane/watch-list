using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class DeleteProductionCountryResponse : IResponse
{
    public bool Success { get; set; }

    public DeleteProductionCountryResponse(bool success)
    {
        Success = success;
    }
}