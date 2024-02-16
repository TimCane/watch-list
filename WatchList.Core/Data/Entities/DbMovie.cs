﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchList.Core.Data.Entities.Interfaces;

namespace WatchList.Core.Data.Entities
{
    [Table("Movie")]
    public class DbMovie : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }


        public string Title { get; set; }

        public string Overview { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int Runtime { get; set; }

        public virtual DbCollection Collection { get; set; }
        public virtual ICollection<DbMovieGenre> Genres { get; set; }
        public virtual ICollection<DbMovieProductionCompany> ProductionCompanies { get; set; }
        public virtual ICollection<DbMovieProductionCountry> ProductionCountries { get; set; }
        public virtual ICollection<DbMovieLanguage> Languages { get; set; }
        public virtual ICollection<DbMovieKeyword> Keywords { get; set; }
        public virtual ICollection<DbMovieCredit> Credits { get; set; }
    }
}
