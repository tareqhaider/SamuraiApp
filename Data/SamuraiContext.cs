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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"(localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppDB";
            
            optionsBuilder.UseSqlServer(connectionString);

        }
    }
}
