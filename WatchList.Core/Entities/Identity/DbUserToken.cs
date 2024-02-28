using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;
using WatchList.Core.Models;

namespace WatchList.Core.Entities.Identity
{

    [Table("UserToken")]
    public class DbUserToken : IIdEntity
    {
        public virtual DbUser User { get; set; }

        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        

        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        
    }
}
