namespace WatchList.Seed.Models
{
    public class CsvKeyword
    {
        public int id { get; set; }

        public List<KeywordItem> keywords { get; set; }
    }

    public class KeywordItem
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}