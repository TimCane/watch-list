using Microsoft.EntityFrameworkCore;

namespace WatchList.Core.Entities.Editor.Extensions
{
    public static class DbMovieGenreExtensions
    {
        public static ModelBuilder WithDbMovieGenre(this ModelBuilder builder)
        {
            builder.Entity<DbMovieGenre>(entity =>
            {
                entity.HasKey(p => new {p.MovieId, p.GenreId});
                entity.Property(e => e.MovieId).HasMaxLength(128);
                entity.Property(e => e.GenreId).HasMaxLength(128);
            });

                builder.Entity<DbMovieGenre>()
                .HasOne(c => c.Genre)
                .WithMany(e => e.Movies);

            builder.Entity<DbMovieGenre>()
                .HasOne(c => c.Movie)
                .WithMany(e => e.Genres);
            
            return builder;
        }
    }
}
