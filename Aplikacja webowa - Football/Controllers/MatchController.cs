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
            var model = new Match();
            model.PlayStage = "Group";
            model.HomeScoreP = 0;
            model.VisitorScoreP = 0;
            ViewData["Stages"] = Enum.GetValues(typeof(Football.Entities.Stage));
            try
            {
                ViewBag.Countries = await _context.Countries.ToListAsync();
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
        public async Task<IActionResult> CreateTournamentMatch(string stage)
        {
            var groupTeams = new List<GroupTeamViewModel>();
            var model = new Match();
            ViewData["Stages"] = Enum.GetValues(typeof(Football.Entities.Stage));
            try
            {
                var matchList = await _context.Matches.Where(x => x.PlayStage == "Group").ToListAsync();
                var teams = await _context.Countries.ToListAsync();
                foreach (var team in teams)
                {
                    var teamViewModel = new GroupTeamViewModel
                    {
                        CountryName = team.CountryName,
                        GoalsAgainst = 0,
                        GoalsFor = 0,
                        MatchesPlayed = 0,
                        Points = 0,
                        Group = team.Group.ToString()
                    };
                    if (matchList.Any())
                    {
                        var teamMatches = matchList.Where(m => m.HomeId == team.CountryID || m.VisitorId == team.CountryID);
                        teamViewModel.GoalsFor = (int)teamMatches.Sum(m => m.HomeId == team.CountryID ? m.HomeScore : m.VisitorScore);
                        teamViewModel.GoalsAgainst = (int)teamMatches.Sum(m => m.HomeId == team.CountryID ? m.VisitorScore : m.HomeScore);
                        teamViewModel.MatchesPlayed = teamMatches.Count();
                        teamViewModel.Points = teamMatches.Sum(m => m.HomeId == team.CountryID
                            ? (m.HomeScore > m.VisitorScore ? 3 : m.HomeScore == m.VisitorScore ? 1 : 0)
                            : (m.VisitorScore > m.HomeScore ? 3 : m.VisitorScore == m.HomeScore ? 1 : 0));
                    }
                    groupTeams.Add(teamViewModel);
                }
                switch (stage)
                {
                    case "QuarterFinal":
                        var groups = groupTeams.Select(team => team.Group).Distinct().ToList();
                        var topTwoTeams = new List<string>();
                        foreach (var group in groups)
                        {
                            var groupTeamsInGroup = groupTeams.Where(team => team.Group == group);
                            var teamsInGroupCount = groupTeamsInGroup.Count();
                            var requiredMatches = teamsInGroupCount - 1;

                            var topTwoTeamsInGroup = groupTeamsInGroup
                                .OrderByDescending(team => team.Points)
                                .ThenByDescending(team => team.GoalsFor - team.GoalsAgainst)
                                .Take(2)
                                .Select(team => team.CountryName)
                                .ToList();

                            // Sprawdzenie liczby rozegranych meczów dla każdej drużyny
                            if (topTwoTeamsInGroup.Count == 2 && groupTeamsInGroup.All(team => team.MatchesPlayed >= requiredMatches))
                            {
                                topTwoTeams.AddRange(topTwoTeamsInGroup);
                            }
                            else
                            {
                                ViewBag.ErrorMessage = "Nie rozegrano odpowiedniej ilości meczów w grupie aby dodać kolejne mecze";
                                return View("Error");
                            }
                        }
                        if (topTwoTeams.Any())
                        {
                            ViewBag.Countries = await _context.Countries
                            .Where(country => topTwoTeams.Contains(country.CountryName))
                            .ToListAsync();
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Brak meczów na poprzednim szczeblu";
                            return View("Error");
                        }
                        return View("CreateMatchForm");

                    case "SemiFinal":
                        var quarterFinalMatches = await _context.Matches
                            .Where(match => match.PlayStage == "QuarterFinal")
                            .ToListAsync();

                        var quarterFinalWinners = quarterFinalMatches
                            .Where(match => match.HomeScore > match.VisitorScore)
                            .Select(match => match.HomeId)
                            .Concat(quarterFinalMatches
                            .Where(match => match.VisitorScore > match.HomeScore)
                            .Select(match => match.VisitorId))
                            .Distinct()
                            .ToList();
                        if (quarterFinalWinners.Any())
                        {
                            ViewBag.Countries = await _context.Countries
                                .Where(country => quarterFinalWinners.Contains(country.CountryID))
                                .ToListAsync();
                            return View("CreateMatchForm");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Brak meczów na poprzednim szczeblu";
                            return View("Error");
                        }

                    case "Final":
                        var semiFinalMatches = await _context.Matches
                            .Where(match => match.PlayStage == "SemiFinal")
                            .ToListAsync();

                        var semiFinalWinners = semiFinalMatches
                            .Where(match => match.HomeScore > match.VisitorScore)
                            .Select(match => match.HomeId)
                            .Concat(semiFinalMatches
                            .Where(match => match.VisitorScore > match.HomeScore)
                            .Select(match => match.VisitorId))
                            .Distinct()
                            .ToList();

                        if (semiFinalWinners.Any())
                        {
                            ViewBag.Countries = await _context.Countries
                                .Where(country => semiFinalWinners.Contains(country.CountryID))
                                .ToListAsync();
                            return View("CreateMatchForm");
                        }
                        else
                        {
                            ViewBag.ErrorMessage = "Brak meczów na poprzednim szczeblu";
                            return View("Error");
                        }
                }

                return View("CreateMatchForm");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
        public async Task<IActionResult> TournamentTree()
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

                var quarterFinalMatches = sortedMatches.Where(m => m.PlayStage == "QuarterFinal").ToList();
                var semiFinalMatches = sortedMatches.Where(m => m.PlayStage == "SemiFinal").ToList();
                var finalMatch = sortedMatches.FirstOrDefault(m => m.PlayStage == "Final");

                return View("TournamentTree", new TournamentTreeViewModel
                {
                    QuarterFinalMatches = quarterFinalMatches,
                    SemiFinalMatches = semiFinalMatches,
                    FinalMatch = finalMatch
                });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

    }

}
