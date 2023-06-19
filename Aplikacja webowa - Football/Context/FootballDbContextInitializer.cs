using Football.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Football.Context
{
    public static class FootballDbContextInitializer
    {
        public static void Initialize(FootballDbContext context)
        {
            if (!context.Database.CanConnect())
            {
                context.Database.EnsureCreated();
            }

            if (!context.Coaches.Any())
            {
                // Dodawanie danych do tabeli Coach
                var coaches = new List<Coach>
                {
                    new Coach { Firstname = "Didier", Lastname = "Deschamps" },
                    new Coach { Firstname = "Vladimir", Lastname = "Petkovic" },
                    new Coach { Firstname = "Gianni", Lastname = "De Biasi" },
                    new Coach { Firstname = "Anghel", Lastname = "Iordanescu" }
                };
                context.Coaches.AddRange(coaches);
                context.SaveChanges();
            }

            if (!context.Countries.Any())
            {
                // Dodawanie danych do tabeli Country
                var countries = new List<Country>
                {
                    new Country { CoachID = 1, CountryName = "France", Group = Group.A.ToString() },
                    new Country { CoachID = 2, CountryName = "Romania", Group = Group.B.ToString() },
                    new Country { CoachID = 3, CountryName = "Albania", Group = Group.A.ToString() },
                    new Country { CoachID = 4, CountryName = "Switzerland", Group = Group.B.ToString() }
                };
                context.Countries.AddRange(countries);
                context.SaveChanges();
            }

            if (!context.Players.Any())
            {
                // Dodawanie danych do tabeli Player
                var players = new List<Player>
                {
                    new Player
                    {
                        CountryID = 3,
                        PlayerFullName = "Etrit Berisha",
                        Position = PositionType.GK.ToString(),
                        Age = 16,
                        Club = "Lazioo"
                    }
                    // Dodaj pozostałe rekordy dla tabeli Player
                };
                context.Players.AddRange(players);
                context.SaveChanges();
            }
        }
    }
}
