using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WatchList.Core.Enums;

namespace WatchList.Core.Models.Requests
{
    public class PagedRequest
    {
        [Range(0, int.MaxValue)]
        [JsonPropertyName("skip")]
        public int Skip { get; set; }

        [Range(1, 10)]
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
            this.Skip = 0;
            this.Take = 10;
            this.Search = "";
            this.SortField = "";
            this.SortOrder = 0;
        }
        public PagedRequest(int skip, int take)
        {
            this.Skip = skip < 0 ? 0 : skip;
            this.Take = take > 10 ? 10 : take;
            this.Search = "";
            this.SortField = "";
            this.SortOrder = 0;
        }
    }
}
