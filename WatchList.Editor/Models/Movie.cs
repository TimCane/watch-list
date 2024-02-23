namespace WatchList.Editor.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }


        public string Title { get; set; }

        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Runtime { get; set; }
    }
}