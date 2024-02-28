using Microsoft.EntityFrameworkCore;

namespace WatchList.Core.Entities.Editor.Extensions
{
    public static class DbMovieCreditExtensions
    {
        public static ModelBuilder WithDbMovieCredit(this ModelBuilder builder)
        {
            builder.Entity<DbMovieCredit>(entity =>
            {
                entity.HasKey(p => new {p.MovieId, p.CreditId});
                entity.Property(e => e.MovieId).HasMaxLength(128);
                entity.Property(e => e.CreditId).HasMaxLength(128);
            });

                builder.Entity<DbMovieCredit>()
                .HasOne(c => c.Credit)
                .WithMany(e => e.Movies);

            builder.Entity<DbMovieCredit>()
                .HasOne(c => c.Movie)
                .WithMany(e => e.Credits);

            return builder;
        }
    }
}
