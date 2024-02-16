using Microsoft.EntityFrameworkCore;
using WatchList.Core.Data.Entities;
using WatchList.Core.Data.Entities.Extensions;
using WatchList.Core.Data.Entities.Interfaces;

namespace WatchList.Core.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbUserPrompt> DbUserPrompts { get; set; }
        public DbSet<DbUserToken> DbUserTokens { get; set; }

        public DbSet<DbCollection> DbCollections { get; set; }
        public DbSet<DbCredit> DbCredits { get; set; }
        public DbSet<DbGenre> DbGenres { get; set; }
        public DbSet<DbKeyword> DbKeywords { get; set; }
        public DbSet<DbLanguage> DbLanguages { get; set; }
        public DbSet<DbMovie> DbMovies { get; set; }
        public DbSet<DbProductionCompany> DbProductionCompanies { get; set; }
        public DbSet<DbProductionCountry> DbProductionCountries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure each entity type
            modelBuilder
                .WithDbUser()
                .WithDbUserPrompt()
                .WithDbUserToken()

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

        public override int SaveChanges()
        {
            OnSave();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            OnSave();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnSave()
        {
            var entries = ChangeTracker
            .Entries()
                .Where(e => e.Entity is IEntity && e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                var now = DateTime.UtcNow;

                ((IEntity)entityEntry.Entity).ModifiedOn = now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IEntity)entityEntry.Entity).CreatedOn = now;
                }
            }
        }
    }
}
