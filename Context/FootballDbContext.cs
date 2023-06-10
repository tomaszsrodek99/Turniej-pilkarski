using Football.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Context
{
    public class FootballDbContext : DbContext
    {
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }
        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options)
        {

        }
        // Metoda pozwala na wskazanie i konfigurację źródła danych
        // Przykład użycia był doskonale widoczny w poprzednim wpisie
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=((localdb)\\MSSQLLocalDB;Database=Football;Trusted_Connection=True;",
                x => x.MigrationsHistoryTable("__EFMigrationHistory", "Identity"));

            }
        }
    }
}
