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

        public async Task<IActionResult> Details(int countryId)
        {
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
    }
}
