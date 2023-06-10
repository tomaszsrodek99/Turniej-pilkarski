using Football.Context;
using Football.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Controllers
{
    public class CountryController : Controller
    {
        private readonly FootballDbContext _context;
        public CountryController(FootballDbContext context)
        {
            _context = context;
        }
        public IActionResult AddClub(Coach coach)
        {
            return View("CreateCoachForm");
        }
        public async Task<IActionResult> CreateCoach(Coach coach)
        {
            if (ModelState.IsValid)
            {
                _context.Coaches.Add(coach);

                await _context.SaveChangesAsync();
                var newCoach = await _context.Coaches.FirstOrDefaultAsync(x => x.Lastname == coach.Lastname);

                return RedirectToAction("AddTeam", newCoach);

            }
            return View("CreateClubForm");
        }
        public IActionResult AddTeam(Coach coach)
        {
            ViewData["CoachId"] = coach.CoachID;
            return View("CreateClubForm");
        }
        public async Task<IActionResult> CreateClub(Country country, int coachId)
        {
            country.CoachID = coachId;
            if (ModelState.IsValid)
            {
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("CreateClubForm");
        }
    }
}
