using Microsoft.EntityFrameworkCore;
using WatchList.Core.Data;
using WatchList.Editor.Entities;
using WatchList.Editor.Extensions;

namespace WatchList.Editor.Data
{
    public class EditorContext : DatabaseContext<EditorContext>
    {
        public EditorContext(DbContextOptions<EditorContext> options)
            : base(options)
        {
        }


        public DbSet<DbCollection> DbCollections { get; set; }
        public DbSet<DbCredit> DbCredits { get; set; }
        public DbSet<DbGenre> DbGenres { get; set; }
        public DbSet<DbKeyword> DbKeywords { get; set; }
        public DbSet<DbLanguage> DbLanguages { get; set; }
        public DbSet<DbMovie> DbMovies { get; set; }
        public DbSet<DbProductionCompany> DbProductionCompanies { get; set; }
        public DbSet<DbProductionCountry> DbProductionCountries { get; set; }

        public DbSet<DbMovieGenre> MovieGenres { get; set; }
        public DbSet<DbMovieProductionCompany> MovieProductionCompanies { get; set; }
        public DbSet<DbMovieProductionCountry> MovieProductionCountries { get; set; }
        public DbSet<DbMovieLanguage> MovieLanguages { get; set; }
        public DbSet<DbMovieKeyword> MovieKeywords { get; set; }
        public DbSet<DbMovieCredit> MovieCredits { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WatchList;Integrated Security=True;TrustServerCertificate=True");
            optionsBuilder
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure each entity type
            modelBuilder
                .WithDbMovie()
                .WithDbCollection()

                .WithDbGenre()
                .WithDbMovieGenre()
                
                .WithDbCredit()
                .WithDbMovieCredit()

                .WithDbKeyword()
                .WithDbMovieKeyword()

                .WithDbLanguage()
                .WithDbMovieLanguage()

                .WithDbProductionCompany()
                .WithDbMovieProductionCompany()

                .WithDbProductionCountry()
                .WithDbMovieProductionCountry()

;

            base.OnModelCreating(modelBuilder);
        }
    }
}