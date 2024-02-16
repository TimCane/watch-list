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
    [Table("Credit")]
    public class DbCredit : IEntity
    {
        public Guid Id { get; set; }

        public string Character { get; set; }
        public DbCreditGenderEnum Gender { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public DbCreditTypeEnum Type { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }


        public virtual ICollection<DbMovieCredit> Movies { get; set; }
    }
}
