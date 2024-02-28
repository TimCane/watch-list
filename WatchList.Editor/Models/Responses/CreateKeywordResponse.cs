using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CreateKeywordResponse : IResponse
{
    public Keyword Keyword { get; set; }

    public CreateKeywordResponse(Keyword keyword)
    {
        Keyword = keyword;
    }
}