namespace WatchList.Editor.Models
{
    public class Language
    {
        public Guid Id { get; set; }
        public string? Iso { get; set; }
        public string? Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }


        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}