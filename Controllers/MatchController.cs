using Football.Context;
using Football.Entities;
using Football.Models;
using Microsoft.AspNetCore.Mvc;
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
                    HomeId = m.HomeId.ToString(),
                    VisitorId = m.VisitorId.ToString(),
                    HomeGoals = m.HomeScore ?? 0,
                    VisitorGoals = m.VisitorScore ?? 0,
                    MatchDate = m.MatchDate ?? DateTime.MinValue,
                    PlayStage = m.PlayStage,
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

        public async Task<IActionResult> CreateMatch()
        {
            try
            {
                ViewBag.Countries = await _context.Countries.ToListAsync();
                ViewData["Stages"] = Enum.GetValues(typeof(Football.Entities.Stage));
                var model = new Match
                {
                    PlayStage = ""
                };
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
            var model = match;
            var one = model.HomeId;
            var two = model.HomeScore;
            var three = model.MatchDate;
            var four = model.PlayStage;
            var five = model.HomeScoreP;
            try
            {
                if (match.HomeScoreP == null)
                    match.HomeScoreP = 0;
                if(match.VisitorScoreP == null)
                    match.VisitorScoreP = 0;

                if (ModelState.IsValid)
                {
                    _context.Matches.Add(match);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("MatchesView");
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }           
        }

    }
}
