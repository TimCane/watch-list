using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses;

public class UpdateLanguageResponse : IResponse
{
    public Language Language { get; set; }

    public UpdateLanguageResponse(Language language)
    {
        Language = language;
    }
}