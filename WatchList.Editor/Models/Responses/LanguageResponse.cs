using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class LanguageResponse : IResponse
{
    public Language Language { get; set; }

    public LanguageResponse(Language language)
    {
        Language = language;
    }
}