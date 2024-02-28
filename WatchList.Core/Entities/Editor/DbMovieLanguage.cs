﻿using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Identity;
using WatchList.Core.Entities.Interfaces;
using WatchList.Core.Models;

namespace WatchList.Core.Entities.Editor
{
    [Table("MovieLanguage")]
    public class DbMovieLanguage : IEntity
    {
        public Guid MovieId { get; set; }
        public Guid LanguageId { get; set; }

        public virtual DbMovie Movie { get; set; }
        public virtual DbLanguage Language { get; set; }

        public DateTime CreatedOn { get; set; }
        public Guid CreatedBy { get; set; }
        

        public DateTime ModifiedOn { get; set; }
        public Guid ModifiedBy { get; set; }
        
    }
}