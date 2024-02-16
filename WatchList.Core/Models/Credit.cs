namespace WatchList.Core.Models
{
    public class Credit
    {
        public Guid Id { get; set; }

        public string Character { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public string Type { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}