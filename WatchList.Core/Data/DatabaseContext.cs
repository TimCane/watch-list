using Microsoft.EntityFrameworkCore;
using WatchList.Core.Entities.Interfaces;

namespace WatchList.Core.Data
{
    public class DatabaseContext<TContext> : DbContext where TContext : DbContext
    {
        public DatabaseContext(DbContextOptions<TContext> options)
            : base(options)
        {
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
                .Where(e => e is {Entity: IEntity, State: EntityState.Added or EntityState.Modified});

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
