using Microsoft.EntityFrameworkCore;
using WatchList.Core.Data.Entities;
using WatchList.Core.Data.Entities.Extensions;
using WatchList.Core.Data.Entities.Interfaces;

namespace WatchList.Core.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<DbUser> Users { get; set; }
        public DbSet<DbUserPrompt> DbUserPrompts { get; set; }

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
                .WithDbUserPrompt();

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            OnSave();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            OnSave();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void OnSave()
        {
            var entries = ChangeTracker
            .Entries()
                .Where(e => e.Entity is IEntity && e.State is EntityState.Added or EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                var now = DateTime.UtcNow;

                ((IEntity)entityEntry.Entity).ModifiedOn = now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((IEntity)entityEntry.Entity).CreatedOn = now;
                }
            }
        }
    }
}
