using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Data.Entities.Extensions
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
