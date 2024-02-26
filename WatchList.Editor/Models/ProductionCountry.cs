namespace WatchList.Editor.Models
{
    public class ProductionCountry
    {
        public Guid Id { get; set; }
        public string? Iso { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}