using Microsoft.EntityFrameworkCore;
using WatchList.Editor.Entities;

namespace WatchList.Editor.Extensions
{
    public static class DbCreditExtensions
    {
        public static ModelBuilder WithDbCredit(this ModelBuilder builder)
        {
            builder.Entity<DbCredit>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbCredit>()
                .HasMany(c => c.Movies)
                .WithOne(e => e.Credit);

            builder
                .Entity<DbCredit>()
                .Property(d => d.Type)
                .HasConversion<string>();

            return builder;
        }
    }
}
