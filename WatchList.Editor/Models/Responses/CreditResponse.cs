using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CreditResponse : IResponse
{
    public Credit Credit { get; set; }
    public CreditResponse(Credit credit)
    {
        Credit = credit;
    }
}