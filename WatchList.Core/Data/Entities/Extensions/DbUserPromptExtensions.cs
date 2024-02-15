using Microsoft.EntityFrameworkCore;

namespace WatchList.Core.Data.Entities.Extensions
{
    public static class DbUserPromptExtensions
    {
        public static ModelBuilder WithDbUserPrompt(this ModelBuilder builder)
        {
            builder.Entity<DbUserPrompt>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbUserPrompt>()
                .HasOne(r => r.User)
                .WithMany(r => r.UserPrompts);

            builder
                .Entity<DbUserPrompt>()
                .Property(d => d.Status)
                .HasConversion<string>();

            builder
                .Entity<DbUserPrompt>()
                .Property(d => d.Type)
                .HasConversion<string>();

            return builder;
        }
    }
}
