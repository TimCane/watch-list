using Microsoft.EntityFrameworkCore;

namespace WatchList.Core.Data.Entities.Extensions
{
    public static class DbUserExtensions
    {
        public static ModelBuilder WithDbUser(this ModelBuilder builder)
        {
            builder.Entity<DbUser>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbUser>()
                .HasMany(c => c.UserPrompts)
                .WithOne(e => e.User);

            return builder;
        }
    }
}
