using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("MovieKeyword")]
    public class DbMovieKeyword : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid KeywordId { get; set; }

        public virtual DbMovie Movie { get; set; }
        public virtual DbKeyword Keyword { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
