using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Data.Entities.Extensions
{
    public static class DbProductionCompanyExtensions
    {
        public static ModelBuilder WithDbProductionCompany(this ModelBuilder builder)
        {
            builder.Entity<DbProductionCompany>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbProductionCompany>()
                .HasMany(c => c.Movies)
                .WithOne(e => e.ProductionCompany);

            return builder;
        }
    }
}
