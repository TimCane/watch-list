using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Requests;

public class UpdateKeywordRequest : IRequest
{
    public string Name { get; set; }
}