using System.ComponentModel.DataAnnotations.Schema;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Editor.Entities
{
    [Table("Movie")]
    public class DbMovie : IIdEntity
    {
        public Guid Id { get; set; }
        public bool? Adult { get; set; }
        public int? Budget { get; set; }
        public string? Homepage { get; set; }
        public virtual DbLanguage? Language { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public int? Runtime { get; set; }
        public string? TagLine { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual DbCollection? Collection { get; set; }
        public virtual ICollection<DbMovieGenre> Genres { get; set; }
        public virtual ICollection<DbMovieProductionCompany> ProductionCompanies { get; set; }
        public virtual ICollection<DbMovieProductionCountry> ProductionCountries { get; set; }
        public virtual ICollection<DbMovieLanguage> Languages { get; set; }
        public virtual ICollection<DbMovieKeyword> Keywords { get; set; }
        public virtual ICollection<DbMovieCredit> Credits { get; set; }
    }
}
