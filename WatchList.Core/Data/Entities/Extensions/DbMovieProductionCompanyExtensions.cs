using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Data.Entities.Extensions
{
    public static class DbMovieProductionCompanyExtensions
    {
        public static ModelBuilder WithDbMovieProductionCompany(this ModelBuilder builder)
        {
            builder.Entity<DbMovieProductionCompany>(entity =>
            {
                entity.HasKey(p => new {p.MovieId, p.ProductionCompanyId});
                entity.Property(e => e.MovieId).HasMaxLength(128);
                entity.Property(e => e.ProductionCompanyId).HasMaxLength(128);
            });

                builder.Entity<DbMovieProductionCompany>()
                .HasOne(c => c.ProductionCompany)
                .WithMany(e => e.Movies);

            builder.Entity<DbMovieProductionCompany>()
                .HasOne(c => c.Movie)
                .WithMany(e => e.ProductionCompanies);

            return builder;
        }
    }
}
