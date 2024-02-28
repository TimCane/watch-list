using Microsoft.EntityFrameworkCore;

namespace WatchList.Core.Entities.Editor.Extensions
{
    public static class DbLanguageExtensions
    {
        public static ModelBuilder WithDbLanguage(this ModelBuilder builder)
        {
            builder.Entity<DbLanguage>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbLanguage>()
                .HasMany(c => c.Movies)
                .WithOne(e => e.Language);

            return builder;
        }
    }
}
