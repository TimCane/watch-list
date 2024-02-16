using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Data.Entities.Extensions
{
    public static class DbMovieLanguageExtensions
    {
        public static ModelBuilder WithDbMovieLanguage(this ModelBuilder builder)
        {
            builder.Entity<DbMovieLanguage>(entity =>
            {
                entity.HasKey(p => new {p.MovieId, p.LanguageId});
                entity.Property(e => e.MovieId).HasMaxLength(128);
                entity.Property(e => e.LanguageId).HasMaxLength(128);
            });

                builder.Entity<DbMovieLanguage>()
                .HasOne(c => c.Language)
                .WithMany(e => e.Movies);

            builder.Entity<DbMovieLanguage>()
                .HasOne(c => c.Movie)
                .WithMany(e => e.Languages);

            return builder;
        }
    }
}
