using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("MovieProductionCompany")]
    public class DbMovieProductionCompany : IManyToManyEntity
    {
        public Guid MovieId { get; set; }
        public Guid ProductionCompanyId { get; set; }

        public virtual DbMovie Movie { get; set; }
        public virtual DbProductionCompany ProductionCompany { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
