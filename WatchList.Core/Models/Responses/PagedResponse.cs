using Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Enums;
using WatchList.Core.Models.Requests;
using WatchList.Core.Models.Responses.Interfaces;

namespace WatchList.Core.Models.Responses
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
