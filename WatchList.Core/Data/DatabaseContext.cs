using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WatchList.Core.Entities.Editor;
using WatchList.Core.Entities.Editor.Extensions;
using WatchList.Core.Entities.Identity;
using WatchList.Core.Entities.Identity.Extensions;
using WatchList.Core.Entities.Interfaces;
using WatchList.Core.Models;

namespace WatchList.Core.Data
{
    public class DatabaseContext : DbContext
    {
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

        public DbSet<DbMovieGenre> MovieGenres { get; set; }
        public DbSet<DbMovieProductionCompany> MovieProductionCompanies { get; set; }
        public DbSet<DbMovieProductionCountry> MovieProductionCountries { get; set; }
        public DbSet<DbMovieLanguage> MovieLanguages { get; set; }
        public DbSet<DbMovieKeyword> MovieKeywords { get; set; }
        public DbSet<DbMovieCredit> MovieCredits { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=.;Initial Catalog=WatchList;Integrated Security=True;TrustServerCertificate=True");
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
                .WithDbMovieProductionCountry();

            base.OnModelCreating(modelBuilder);
        }
        
        public readonly Guid UserId;
        public DatabaseContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            if (httpContextAccessor?.HttpContext?.Items["User"] is User user)
            {
                UserId = user.Id ?? new Guid("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF");
            }
            else
            {
                UserId = new Guid("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF");
            }
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

        public void OnSave()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e is { Entity: IEntity, State: EntityState.Added or EntityState.Modified });

            foreach (var entityEntry in entries)
            {
                var now = DateTime.UtcNow;

                ((IEntity)entityEntry.Entity).ModifiedOn = now;
                ((IEntity)entityEntry.Entity).ModifiedBy = UserId;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IEntity)entityEntry.Entity).CreatedOn = now;
                    ((IEntity)entityEntry.Entity).CreatedBy = UserId;
                }
            }
        }
    }
}
