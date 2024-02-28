namespace WatchList.Editor.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public bool? Adult { get; set; }
        public int? Budget { get; set; }
        public string? Homepage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public int? Runtime { get; set; }
        public string? TagLine { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }


        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}