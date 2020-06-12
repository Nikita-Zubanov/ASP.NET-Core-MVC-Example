using Microsoft.EntityFrameworkCore;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class CountriesDbContext : DbContext
    {
        public CountriesDbContext(DbContextOptions<CountriesDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        public DbSet<City> Cities { get; private set; }
        public DbSet<Region> Regions { get; private set; }
        public DbSet<Сountry> Сountries { get; private set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .HasOne(ct => ct.Сountry)
                .WithOne(cntr => cntr.Capital)
                .HasForeignKey<Сountry>(cntr => cntr.CityId);

            modelBuilder.Entity<Region>()
                .HasMany(rgn => rgn.Сountries)
                .WithOne(cntr => cntr.Region)
                .HasForeignKey(cntr => cntr.RegionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}