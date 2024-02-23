using Microsoft.EntityFrameworkCore;
using WatchList.Core.Data;
using WatchList.Identity.Entities;
using WatchList.Identity.Extensions;

namespace WatchList.Identity.Data
{
    public class IdentityContext : DatabaseContext<IdentityContext>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbUserPrompt> DbUserPrompts { get; set; }
        public DbSet<DbUserToken> DbUserTokens { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure each entity type
            modelBuilder
                .WithDbUser()
                .WithDbUserPrompt()
                .WithDbUserToken();

            base.OnModelCreating(modelBuilder);
        }
    }
}
