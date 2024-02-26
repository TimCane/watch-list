namespace WatchList.Editor.Models
{
    public class Collection
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}