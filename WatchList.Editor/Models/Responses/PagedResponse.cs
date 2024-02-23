using WatchList.Core.Enums;
using WatchList.Core.Models.Interfaces;

namespace WatchList.Editor.Models.Responses
{
    public class PagedResponse : IResponse
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public int Total { get; set; }
        public string Search { get; set; }
        public string SortField { get; set; }
        public SortOrderEnum SortOrder { get; set; }
    }
}
