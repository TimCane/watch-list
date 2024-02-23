using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("MovieCredit")]
    public class DbMovieCredit : IManyToManyEntity
    {
        public Guid MovieId { get; set; }
        public Guid CreditId { get; set; }

        public virtual DbMovie Movie { get; set; }
        public virtual DbCredit Credit { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
