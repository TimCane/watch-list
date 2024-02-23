using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("MovieLanguage")]
    public class DbMovieLanguage : IManyToManyEntity
    {
        public Guid MovieId { get; set; }
        public Guid LanguageId { get; set; }

        public virtual DbMovie Movie { get; set; }
        public virtual DbLanguage Language { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
