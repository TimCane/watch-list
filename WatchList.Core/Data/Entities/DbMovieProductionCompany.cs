using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Data.Entities.Interfaces;

namespace WatchList.Core.Data.Entities
{
    [Table("MovieProductionCompany")]
    public class DbMovieProductionCompany : IManyToManyEntity
    {
        public Guid MovieId { get; set; }
        public Guid ProductionCompanyId { get; set; }

        public virtual DbMovie Movie { get; set; }
        public virtual DbProductionCompany ProductionCompany { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
