using MetricConverter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MetricConverter.Infrastructure.Configuration
{
    public class MetricConverterContext :DbContext
    {
        public MetricConverterContext(DbContextOptions<MetricConverterContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MetricTypeEntity>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<MetricUnitEntity>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd(); 

            modelBuilder.Entity<MetricFormulaEntity>()
                 .Property(p => p.Id)
                 .ValueGeneratedOnAdd();
        }

        public DbSet<MetricTypeEntity> MetricType { get; set; }
        public DbSet<MetricUnitEntity> MetricUnit { get; set; }
        public DbSet<MetricFormulaEntity> MetricFormula { get; set; }

    }
}
