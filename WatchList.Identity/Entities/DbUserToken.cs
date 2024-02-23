using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Identity.Entities
{

    [Table("UserToken")]
    public class DbUserToken : IEntity
    {
        public virtual DbUser User { get; set; }

        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
