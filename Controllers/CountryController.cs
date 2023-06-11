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
        public IActionResult AddClub()
        {
            return View("CreateCoachForm");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoach(Coach coach)
        {
            if (ModelState.IsValid)
            {
                var isExistingCoach = await _context.Coaches.AnyAsync(x => x.Lastname == coach.Lastname && x.Firstname == coach.Firstname);

                if (isExistingCoach)
                {
                    ModelState.AddModelError("Firstname", "Trener o podanym imieniu i nazwisku już istnieje.");
                    ModelState.AddModelError("Lastname", "Trener o podanym imieniu i nazwisku już istnieje.");
                    return View("CreateClubForm");
                }

                _context.Coaches.Add(coach);
                await _context.SaveChangesAsync();

                var newCoach = await _context.Coaches.FirstOrDefaultAsync(x => x.Lastname == coach.Lastname && x.Firstname == coach.Firstname);

                return RedirectToAction("AddTeam", newCoach);
            }

            return View("CreateClubForm");
        }

        public IActionResult AddTeam(Coach coach)
        {
            ViewData["CoachId"] = coach.CoachID;
            return View("CreateClubForm");
        }
        [HttpPost]
        public async Task<IActionResult> CreateClub(Country country, int coachId)
        {
            var coach = await _context.Coaches.FindAsync(coachId);
            country.Coach = coach;
            if (ModelState.IsValid)
            {
                var isExistingClub = await _context.Countries.AnyAsync(x => x.CountryName == country.CountryName);
                if (isExistingClub)
                {
                    ModelState.AddModelError("CountryName", "Drużyna o podanej nazwie istnieje.");
                    _context.Coaches.Remove(coach);
                    await _context.SaveChangesAsync();
                    return View("CreateClubForm");
                }
                _context.Countries.Add(country);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("CreateClubForm");
        }
        public async Task<IActionResult> DeleteClub(int countryId)
        {
            var currentClub = await _context.Countries.FindAsync(countryId);
            _context.Countries.Remove(currentClub);
            await _context.SaveChangesAsync();
            var currentCoach = await _context.Coaches.FindAsync(currentClub.CoachID);
            _context.Coaches.Remove(currentCoach);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> EditClub(int countryId)
        {
            var currentClub = await _context.Countries.FindAsync(countryId);
            var currentCoach = await _context.Coaches.FindAsync(currentClub.CoachID);
            currentClub.Coach = currentCoach;
            return View("EditClubForm", currentClub);
        }
        [HttpPost]
        public async Task<IActionResult> SaveClub(Country country)
        {
            if (ModelState.IsValid)
            {
                var existingCountry = await _context.Countries.FindAsync(country.CountryID);
                if (existingCountry != null)
                {
                    // Sprawdź, czy istnieje inny kraj o takiej samej nazwie
                    var duplicateCountry = await _context.Countries.FirstOrDefaultAsync(c => c.CountryID != country.CountryID && c.CountryName == country.CountryName);
                    if (duplicateCountry != null)
                    {
                        ModelState.AddModelError("CountryName", "Kraj o podanej nazwie już istnieje.");
                        return View("EditClubForm", country.CountryID);
                    }

                    existingCountry.CountryName = country.CountryName;
                    existingCountry.Grupa = country.Grupa;

                    // Pobierz trenera o podanym coachId
                    var coach = await _context.Coaches.FindAsync(country.CoachID);
                    if (coach != null)
                    {
                        // Sprawdź, czy istnieje inny trener o takim samym imieniu i nazwisku
                        var duplicateCoach = await _context.Coaches.FirstOrDefaultAsync(c => c.CoachID != country.CoachID && c.Firstname == country.Coach.Firstname && c.Lastname == country.Coach.Lastname);
                        if (duplicateCoach != null)
                        {
                            ModelState.AddModelError("Coach", "Trener o podanym imieniu i nazwisku już istnieje.");
                            return View("EditClubForm", country.CountryID);
                        }

                        existingCountry.Coach.Firstname = country.Coach.Firstname;
                        existingCountry.Coach.Lastname = country.Coach.Lastname;
                    }

                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
            }

            // Jeśli walidacja nie powiodła się, ponownie wyświetlamy formularz z błędami
            return View("EditClubForm", country.CountryID);
        }

    }
}
