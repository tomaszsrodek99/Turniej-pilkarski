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
            new Country { CoachID = 1, CountryName = "France", Grupa = "A" },
            new Country { CoachID = 2, CountryName = "Romania", Grupa = "A" },
            new Country { CoachID = 3, CountryName = "Albania", Grupa = "A" },
            new Country { CoachID = 4, CountryName = "Switzerland", Grupa = "A" }
        };
                context.Countries.AddRange(countries);
                context.SaveChanges();
            }

            /*if (!context.Matches.Any())
            {
                // Dodawanie danych do tabeli Match
                var matches = new List<Match>
    {
        new Match
        {
            MatchDate = new DateTime(2022, 05, 30),
            HomeId = 6,
            HomeScore = 2,
            VisitorId = 7,
            VisitorScore = 1,
            PlayStage = Stage.Grupa.ToString(),
            PenaltyScore = "N",
            HomeScoreP = null,
            VisitorScoreP = null
        }
        // Dodaj pozostałe rekordy dla tabeli Match
    };
                context.Matches.AddRange(matches);
                context.SaveChanges();
            }
            */
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
