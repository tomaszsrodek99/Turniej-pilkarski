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
        // Metoda OnConfiguring jest wywoływana w momencie konfiguracji kontekstu bazy danych
        // Jeśli już istnieje konfiguracja, to ta metoda nie zostanie wywołana
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Podajemy łańcuch połączenia do naszej bazy danych
                optionsBuilder.UseSqlServer("Server=((localdb)\\MSSQLLocalDB;Database=Football;Trusted_Connection=True;",
                x => x.MigrationsHistoryTable("__EFMigrationHistory", "Identity"));

            }
        }
    }
}
