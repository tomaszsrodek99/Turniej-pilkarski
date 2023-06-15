using Football.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Football.Context;
using System.Linq;
using System;
using Football.Models;

namespace Football.Controllers
{
    public class HomeController : Controller
    {
        private readonly FootballDbContext _context;
        public HomeController(FootballDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                //Utwórz listę zespołów z przypisanymi do nich trenerami
                var teamsWithCoaches = await _context.Countries.Include(c => c.Coach).ToListAsync();

                return View(teamsWithCoaches);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Details(int countryId)
        {
            try
            {
                //Pobierz wszystkie drużyny wraz z trenerem i graczami przypisanymi do drużyny
                var country = await _context.Countries.Include(c => c.Coach).Include(c => c.Players).FirstOrDefaultAsync(c => c.CountryID == countryId);
                Player player = new();
                if (country == null)
                {
                    return NotFound();
                }

                ViewData["Title"] = $"{country.CountryName} - {country.Coach.Firstname} {country.Coach.Lastname}";
                ViewData["Players"] = country.Players.ToList();
                ViewData["CountryId"] = country.CountryID;

                return View(player);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> GroupView()
        {
            try
            {
                //Pobierz wszystkie mecze na szczeblu grupowym
                var matchList = await _context.Matches.Where(x => x.PlayStage == "G").ToListAsync();
                //Utwórz listę naszych nowych modeli dla widoku
                var groupTeams = new List<GroupTeamViewModel>();
                //Pobierz drużyny, które rozegrały już mecze jako gospodarze lub goście
                var teams = await _context.Countries.Where(x=>x.Grupa != "-").ToListAsync();
                //Iteruj przez wszystkie drużyny, przypisująć odpowiednie dane do konkretnych pól nowego modelu
                foreach (var team in teams)
                {
                    //Przypisz nazwę drużyny i grupę na początku
                    var teamViewModel = new GroupTeamViewModel
                    {
                        CountryName = team.CountryName,
                        GoalsAgainst = 0,
                        GoalsFor = 0,
                        MatchesPlayed = 0,
                        Points = 0,
                        Group = team.Grupa.ToString()
                    };
                    //Jeżeli lista nie jest pusta
                    if(matchList.Any())
                    {
                        //Wybierz mecze konkretnej drużyny
                        var teamMatches = matchList.Where(m => m.HomeId == team.CountryID || m.VisitorId == team.CountryID);
                        //Sumuj zdobyte bramki na podstawie meczów w których brały udział jako goście lub gospodarze, sume meczów
                        teamViewModel.GoalsFor = (int)teamMatches.Sum(m => m.HomeId == team.CountryID ? m.HomeScore : m.VisitorScore);
                        teamViewModel.GoalsAgainst = (int)teamMatches.Sum(m => m.HomeId == team.CountryID ? m.VisitorScore : m.HomeScore);
                        teamViewModel.MatchesPlayed = teamMatches.Count();
                        //Zlicz punkty
                        teamViewModel.Points = teamMatches.Sum(m => m.HomeId == team.CountryID
                            ? (m.HomeScore > m.VisitorScore ? 3 : m.HomeScore == m.VisitorScore ? 1 : 0)
                            : (m.VisitorScore > m.HomeScore ? 3 : m.VisitorScore == m.HomeScore ? 1 : 0));
                    }
                    groupTeams.Add(teamViewModel);
                }              
                return View("GroupView", groupTeams);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }         
        }

    }
}
