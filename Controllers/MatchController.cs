using FluentValidation;
using FluentValidation.Results;
using Football.Context;
using Football.Entities;
using Football.Models;
using Football.Models.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Controllers
{
    public class MatchController : Controller
    {
        private readonly FootballDbContext _context;
        public MatchController(FootballDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> MatchesView()
        {
            try
            {
                var matches = await _context.Matches.ToListAsync();

                var matchViewModels = matches.Select(m => new MatchViewModel
                {
                    MatchId = m.MatchID,
                    HomeId = GetCountryNameById(m.HomeId),
                    VisitorId = GetCountryNameById(m.VisitorId),
                    HomeGoals = m.HomeScore ?? 0,
                    VisitorGoals = m.VisitorScore ?? 0,
                    MatchDate = m.MatchDate ?? DateTime.MinValue,
                    PlayStage = m.PlayStage.ToString(),
                    HomeGoalsP = m.HomeScoreP ?? 0,
                    VisitorGoalsP = m.VisitorScoreP ?? 0
                }).ToList();

                var sortedMatches = matchViewModels.OrderBy(m => m.MatchDate).ThenByDescending(m => m.PlayStage).ToList();

                return View("MatchView", sortedMatches);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        private string GetCountryNameById(int countryId)
        {
            var country = _context.Countries.FirstOrDefault(c => c.CountryID == countryId);
            return country != null ? country.CountryName : string.Empty;
        }

        public async Task<IActionResult> DeleteMatch(int matchId)
        {
            try
            {
                var match = await _context.Matches.FindAsync(matchId);

                _context.Matches.Remove(match);
                await _context.SaveChangesAsync();

                return RedirectToAction("MatchesView");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
        public async Task<IActionResult> CreateMatch()
        {
            try
            {
                ViewBag.Countries = await _context.Countries.ToListAsync();
                ViewData["Stages"] = Enum.GetValues(typeof(Football.Entities.Stage));
                var model = new Match();
                return View("CreateMatchForm");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMatch(Match match)
        {
            try
            {
                    FluentMatchValidator validator = new FluentMatchValidator(_context, match);
                    ValidationResult result = validator.Validate(match);
                    if (result.IsValid)
                    {
                        _context.Matches.Add(match);
                        await _context.SaveChangesAsync();
                        return RedirectToAction("MatchesView");
                    }

                    foreach (ValidationFailure failure in result.Errors)
                    {
                        ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                    }
                

                ViewBag.Countries = await _context.Countries.ToListAsync();
                ViewData["Stages"] = Enum.GetValues(typeof(Football.Entities.Stage));
                return View("CreateMatchForm", match);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }


       
    }
}
