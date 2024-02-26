using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("Keyword")]
    public class DbKeyword : IIdEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual ICollection<DbMovieKeyword> Movies { get; set; }
    }
}
