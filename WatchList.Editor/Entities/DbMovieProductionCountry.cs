using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("MovieProductionCountry")]
    public class DbMovieProductionCountry : IManyToManyEntity
    {
        public Guid MovieId { get; set; }
        public Guid ProductionCountryId { get; set; }

        public virtual DbMovie Movie { get; set; }
        public virtual DbProductionCountry ProductionCountry { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
