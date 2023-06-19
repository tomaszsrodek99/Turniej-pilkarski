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
        // Metoda wyświetlająca formularz do dodawania trenera, trener musi być stworzony przed utworzeniem klubu
        public IActionResult AddClub()
        {
            return View("CreateCoachForm");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCoach(Coach coach)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Sprawdzamy, czy trener o podanym imieniu i nazwisku już istnieje
                    var isExistingCoach = await _context.Coaches.AnyAsync(x => x.Lastname == coach.Lastname && x.Firstname == coach.Firstname);

                    if (isExistingCoach)
                    {
                        // Jeśli trener już istnieje, dodajemy błąd walidacji dla pól imienia i nazwiska
                        ModelState.AddModelError("Firstname", "Trener o podanym imieniu i nazwisku już istnieje.");
                        ModelState.AddModelError("Lastname", "Trener o podanym imieniu i nazwisku już istnieje.");
                        return View("CreateCoachForm");
                    }

                    _context.Coaches.Add(coach);
                    await _context.SaveChangesAsync();

                    // Pobieramy nowo dodanego trenera i przekazujemy go do akcji, w której skończmym tworzyć klub
                    var newCoach = await _context.Coaches.FirstOrDefaultAsync(x => x.Lastname == coach.Lastname && x.Firstname == coach.Firstname);

                    return RedirectToAction("AddTeam", coach);
                }

                return View("CreateClubForm");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public IActionResult AddTeam(Coach coach)
        {
            ViewData["CoachId"] = coach.CoachID;
            return View("CreateClubForm");
        }
        [HttpPost]
        public async Task<IActionResult> CreateClub(Country country, int coachId)
        {
            try
            {
                var coach = await _context.Coaches.FindAsync(coachId);
                country.Coach = coach;
                if (ModelState.IsValid)
                {
                    // Sprawdzamy, czy drużyna o podanej nazwie już istnieje
                    var isExistingClub = await _context.Countries.AnyAsync(x => x.CountryName == country.CountryName);
                    if (isExistingClub)
                    {
                        // Jeśli drużyna już istnieje, dodajemy błąd walidacji dla pola CountryName
                        ModelState.AddModelError("CountryName", "Drużyna o podanej nazwie istnieje.");
                        // Usuwamy trenera, który został wcześniej dodany
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
            catch (Exception ex)
            {
                var coach = await _context.Coaches.FindAsync(coachId);
                _context.Coaches.Remove(coach);
                await _context.SaveChangesAsync();
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
        public async Task<IActionResult> DeleteClub(int countryId)
        {
            try
            {
                var currentClub = await _context.Countries.FindAsync(countryId);
                var currentCoach = await _context.Coaches.FindAsync(currentClub.CoachID);

                // Usuń wszystkich zawodników z danego kraju kaskadowo
                var players = await _context.Players.Where(p => p.CountryID == countryId).ToListAsync();
                _context.Players.RemoveRange(players);

                _context.Coaches.Remove(currentCoach);
                _context.Countries.Remove(currentClub);

                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> EditClub(int countryId)
        {
            try
            {
                var currentClub = await _context.Countries.FindAsync(countryId);
                var currentCoach = await _context.Coaches.FindAsync(currentClub.CoachID);
                currentClub.Coach = currentCoach;
                return View("EditClubForm", currentClub);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> SaveClub(Country country)
        {
            try {
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
                        existingCountry.Group = country.Group;

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
                return View("EditClubForm", country.CountryID);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}
