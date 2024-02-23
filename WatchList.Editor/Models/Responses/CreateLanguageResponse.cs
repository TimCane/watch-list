using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class CreateLanguageResponse : IResponse
{
    public Language Language { get; set; }

    public CreateLanguageResponse(Language language)
    {
        Language = language;
    }
}