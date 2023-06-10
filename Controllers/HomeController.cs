using Football.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Football.Context;
using System.Linq;

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
            var teamsWithCoaches = await _context.Countries.Include(c => c.Coach).ToListAsync();

            return View(teamsWithCoaches);
        }

        public async Task<IActionResult> Details(int id)
        {
            var country = await _context.Countries.Include(c => c.Coach).Include(c => c.Players).FirstOrDefaultAsync(c => c.CountryID == id);
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

        [HttpPost]
        public async Task<IActionResult> SavePlayer(Player player)
        {
            if (ModelState.IsValid)
            {
                if (player.Club == null)
                    player.Club = "-";

                _context.Players.Add(player);
                await _context.SaveChangesAsync();

            }

            return RedirectToAction("Details", "Home", new { id = player.CountryID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveTeam(string countryName, string coachFirstName, string coachLastName)
        {
            if (ModelState.IsValid)
            {
                var coach = new Coach
                {
                    Firstname = coachFirstName,
                    Lastname = coachLastName
                };
                _context.Coaches.Add(coach);
                //await _context.SaveChangesAsync();
                var coachId = coach.CoachID;
                var country = new Country
                {
                    CountryName = countryName,
                    CoachID = coachId
                };
             
                _context.Countries.Add(country);

                //await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }
    }
}
