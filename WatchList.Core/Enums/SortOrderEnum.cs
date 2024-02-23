using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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
