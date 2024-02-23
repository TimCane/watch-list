using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class KeywordResponse : IResponse
{
    public Keyword Keyword { get; set; }

    public KeywordResponse(Keyword keyword)
    {
        Keyword = keyword;
    }
}