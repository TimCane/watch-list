using Microsoft.EntityFrameworkCore;

namespace WatchList.Core.Entities.Editor.Extensions
{
    public static class DbMovieKeywordExtensions
    {
        public static ModelBuilder WithDbMovieKeyword(this ModelBuilder builder)
        {
            builder.Entity<DbMovieKeyword>(entity =>
            {
                entity.HasKey(p => new {p.MovieId, p.KeywordId});
                entity.Property(e => e.MovieId).HasMaxLength(128);
                entity.Property(e => e.KeywordId).HasMaxLength(128);
            });

                builder.Entity<DbMovieKeyword>()
                .HasOne(c => c.Keyword)
                .WithMany(e => e.Movies);

            builder.Entity<DbMovieKeyword>()
                .HasOne(c => c.Movie)
                .WithMany(e => e.Keywords);

            return builder;
        }
    }
}
