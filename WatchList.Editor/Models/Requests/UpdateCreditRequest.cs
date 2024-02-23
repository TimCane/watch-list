using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Requests;

public class UpdateCreditRequest : IRequest
{
    public string Character { get; set; }
    public string Gender { get; set; }
    public string Name { get; set; }
    public int Order { get; set; }
    public string Type { get; set; }
}