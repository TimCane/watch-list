using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Data.Entities.Extensions
{
    public static class DbKeywordExtensions
    {
        public static ModelBuilder WithDbKeyword(this ModelBuilder builder)
        {
            builder.Entity<DbKeyword>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbKeyword>()
                .HasMany(c => c.Movies)
                .WithOne(e => e.Keyword);



            return builder;
        }
    }
}
