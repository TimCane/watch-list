using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WatchList.Core.Enums;

namespace WatchList.Core.Models
{
    public class PagedRequest
    {
        [Range(0, int.MaxValue)]
        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        [Range(1, 50)]
        [JsonPropertyName("take")]
        public int Take { get; set; }


        [JsonPropertyName("search")]
        public string Search { get; set; }


        [JsonPropertyName("sortField")]
        public string SortField { get; set; }


        [JsonPropertyName("sortOrder")]
        public SortOrderEnum SortOrder { get; set; }


        public PagedRequest()
        {
            Skip = 0;
            Take = 10;
            Search = "";
            SortField = "";
            SortOrder = 0;
        }
        public PagedRequest(int skip, int take)
        {
            Skip = skip < 0 ? 0 : skip;
            Take = take > 10 ? 10 : take;
            Search = "";
            SortField = "";
            SortOrder = 0;
        }
    }
}
