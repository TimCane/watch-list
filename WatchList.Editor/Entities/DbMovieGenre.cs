using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("MovieGenre")]
    public class DbMovieGenre : IManyToManyEntity
    {
        public Guid MovieId { get; set; }
        public Guid GenreId { get; set; }

        public virtual DbMovie Movie { get; set; }
        public virtual DbGenre Genre { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
