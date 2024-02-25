namespace WatchList.Seed.Models
{
    public class CsvCredit
    {
        public List<CreditItem>? cast { get; set; }
        public List<CreditItem>? crew { get; set; }
        public int id { get; set; }
    }

    public class CreditItem
    {
        public string cast_id { get; set; }
        public string character { get; set; }
        public string credit_id { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        public string profile_path { get; set; }
    }
}