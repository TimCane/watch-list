using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class UpdateKeywordResponse : IResponse
{
    public Keyword Keyword { get; set; }

    public UpdateKeywordResponse(Keyword keyword)
    {
        Keyword = keyword;
    }
}