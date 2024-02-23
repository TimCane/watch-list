using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class DeleteProductionCompanyResponse : IResponse
{
    public bool Success { get; set; }

    public DeleteProductionCompanyResponse(bool success)
    {
        Success = success;
    }
}