namespace WatchList.Core.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}