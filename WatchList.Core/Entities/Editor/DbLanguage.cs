using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Identity;
using WatchList.Core.Entities.Interfaces;
using WatchList.Core.Models;

namespace WatchList.Core.Entities.Editor
{
    [Table("Language")]
    public class DbLanguage : IIdEntity
    {
        public Guid Id { get; set; }

        public string? Iso { get; set; }
        public string? Name { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        

        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        
        public virtual ICollection<DbMovieLanguage> Movies { get; set; }
    }
}
