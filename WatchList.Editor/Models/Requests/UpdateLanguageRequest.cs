using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Requests;

public class UpdateLanguageRequest : IRequest
{
    public string Name { get; set; }
}