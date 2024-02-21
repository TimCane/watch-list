using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WatchList.Core.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SortOrderEnum
    {
        [EnumMember(Value = "Asc")]
        Asc = 0,
        [EnumMember(Value = "Desc")]
        Desc = 1
    }
}
