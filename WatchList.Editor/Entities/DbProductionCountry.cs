using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("ProductionCountry")]
    public class DbProductionCountry : IEntity
    {
        public Guid Id { get; set; }
        public string Iso { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual ICollection<DbMovieProductionCountry> Movies { get; set; }
    }
}
