using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Data.Entities.Extensions
{
    public static class DbProductionCountryExtensions
    {
        public static ModelBuilder WithDbProductionCountry(this ModelBuilder builder)
        {
            builder.Entity<DbProductionCountry>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbProductionCountry>()
                .HasMany(c => c.Movies)
                .WithOne(e => e.ProductionCountry);

            return builder;
        }
    }
}
