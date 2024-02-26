using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;
using WatchList.Editor.Enums;

namespace WatchList.Editor.Entities
{
    [Table("Credit")]
    public class DbCredit : IIdEntity
    {
        public Guid Id { get; set; }

        public string? Character { get; set; }
        public DbCreditGenderEnum? Gender { get; set; }
        public string? Name { get; set; }
        public int? Order { get; set; }
        public DbCreditTypeEnum Type { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }


        public virtual ICollection<DbMovieCredit> Movies { get; set; }
    }
}
