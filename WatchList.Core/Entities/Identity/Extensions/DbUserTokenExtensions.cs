using Microsoft.EntityFrameworkCore;

namespace WatchList.Core.Entities.Identity.Extensions
{
    public static class DbUserTokenExtensions
    {
        public static ModelBuilder WithDbUserToken(this ModelBuilder builder)
        {
            builder.Entity<DbUserToken>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbUserToken>()
                .HasOne(r => r.User)
                .WithMany(r => r.UserTokens);

            return builder;
        }
    }
}
