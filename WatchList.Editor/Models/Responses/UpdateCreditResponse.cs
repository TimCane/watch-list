using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class UpdateCreditResponse : IResponse
{
    public Credit Credit { get; set; }
    public UpdateCreditResponse(Credit credit)
    {
        Credit = credit;
    }
}