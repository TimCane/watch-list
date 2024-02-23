using Microsoft.EntityFrameworkCore;
using WatchList.Editor.Entities;

namespace WatchList.Editor.Extensions
{
    public static class DbCollectionExtensions
    {
        public static ModelBuilder WithDbCollection(this ModelBuilder builder)
        {
            builder.Entity<DbCollection>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbCollection>()
                .HasMany(c => c.Movies)
                .WithOne(e => e.Collection);

            return builder;
        }
    }
}
