using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Data.Entities.Extensions
{
    public static class DbMovieProductionCountryExtensions
    {
        public static ModelBuilder WithDbMovieProductionCountry(this ModelBuilder builder)
        {
            builder.Entity<DbMovieProductionCountry>(entity =>
            {
                entity.HasKey(p => new {p.MovieId, p.ProductionCountryId});
                entity.Property(e => e.MovieId).HasMaxLength(128);
                entity.Property(e => e.ProductionCountryId).HasMaxLength(128);
            });

                builder.Entity<DbMovieProductionCountry>()
                .HasOne(c => c.ProductionCountry)
                .WithMany(e => e.Movies);

            builder.Entity<DbMovieProductionCountry>()
                .HasOne(c => c.Movie)
                .WithMany(e => e.ProductionCountries);

            return builder;
        }
    }
}
