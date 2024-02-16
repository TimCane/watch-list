﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchList.Core.Data.Entities.Extensions
{
    public static class DbLanguageExtensions
    {
        public static ModelBuilder WithDbLanguage(this ModelBuilder builder)
        {
            builder.Entity<DbLanguage>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).HasMaxLength(128);
            });

            builder.Entity<DbLanguage>()
                .HasMany(c => c.Movies)
                .WithOne(e => e.Language);

            return builder;
        }
    }
}
