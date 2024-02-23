using Microsoft.EntityFrameworkCore;
using WatchList.Editor.Entities;

namespace WatchList.Editor.Extensions
{
    public static class DbMovieExtensions
    {
        public static ModelBuilder WithDbMovie(this ModelBuilder builder)
        {
            builder.Entity<DbMovie>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbMovie>()
                .HasOne(r => r.Collection)
                .WithMany(r => r.Movies);

            builder.Entity<DbMovie>()
                .HasMany(c => c.Genres)
                .WithOne(e => e.Movie);

            builder.Entity<DbMovie>()
                .HasMany(c => c.ProductionCompanies)
                .WithOne(e => e.Movie);

            builder.Entity<DbMovie>()
                .HasMany(c => c.ProductionCountries)
                .WithOne(e => e.Movie);

            builder.Entity<DbMovie>()
                .HasMany(c => c.Languages)
                .WithOne(e => e.Movie);

            builder.Entity<DbMovie>()
                .HasMany(c => c.Keywords)
                .WithOne(e => e.Movie);

            builder.Entity<DbMovie>()
                .HasMany(c => c.Credits)
                .WithOne(e => e.Movie);

            return builder;
        }
    }
}
