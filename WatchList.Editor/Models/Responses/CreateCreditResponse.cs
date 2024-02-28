using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CreateCreditResponse : IResponse
{
    public Credit Credit { get; set; }
    public CreateCreditResponse(Credit credit)
    {
        Credit = credit;
    }
}