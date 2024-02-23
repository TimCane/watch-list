using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("Language")]
    public class DbLanguage : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public virtual ICollection<DbMovieLanguage> Movies { get; set; }
    }
}
