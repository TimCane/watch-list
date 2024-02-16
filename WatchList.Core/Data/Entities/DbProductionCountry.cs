using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Data.Entities.Interfaces;

namespace WatchList.Core.Data.Entities
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
