using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Data.Entities.Enums;
using WatchList.Core.Data.Entities.Interfaces;

namespace WatchList.Core.Data.Entities
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
