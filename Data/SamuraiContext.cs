using Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Battle> Battles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=DESKTOP-0IO1BPV\SQLEXPRESS;Initial Catalog=SamuraiApp;Integrated Security=True";
            
            optionsBuilder.UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(k => new { k.SamuraiId, k.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horses");
        }

    }
}
