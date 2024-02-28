using Microsoft.EntityFrameworkCore;

namespace WatchList.Core.Entities.Editor.Extensions
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

            builder
                .Entity<DbCredit>()
                .Property(d => d.Gender)
                .HasConversion<string>();

            return builder;
        }
    }
}
