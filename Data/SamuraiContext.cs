using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<Battle> Battles { get; set; }

        public static readonly ILoggerFactory ConsoleLoggerFactory = 
            LoggerFactory.Create( builder =>
            {
                builder.AddFilter((category, level) 
                                                    => category == DbLoggerCategory.Database.Command.Name
                                                    && level == LogLevel.Information)
                       .AddConsole();
            });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=DESKTOP-IP9GKPT\SQLEXPRESS;Initial Catalog=SamuraiApp;Integrated Security=True";
            
            optionsBuilder.UseLoggerFactory(ConsoleLoggerFactory)
                          .UseSqlServer(connectionString);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(k => new { k.SamuraiId, k.BattleId });
            modelBuilder.Entity<Horse>().ToTable("Horses");
        }

    }
}
