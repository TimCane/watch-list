using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Data.Entities.Interfaces;

namespace WatchList.Core.Data.Entities
{
    [Table("MovieKeyword")]
    public class DbMovieKeyword : IManyToManyEntity
    {
        public Guid MovieId { get; set; }
        public Guid KeywordId { get; set; }

        public virtual DbMovie Movie { get; set; }
        public virtual DbKeyword Keyword { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
