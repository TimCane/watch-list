using Microsoft.EntityFrameworkCore;
using WatchList.Editor.Entities;

namespace WatchList.Editor.Extensions
{
    public static class DbGenreExtensions
    {
        public static ModelBuilder WithDbGenre(this ModelBuilder builder)
        {
            builder.Entity<DbGenre>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbGenre>()
                .HasMany(c => c.Movies)
                .WithOne(e => e.Genre);


            return builder;
        }
    }
}
