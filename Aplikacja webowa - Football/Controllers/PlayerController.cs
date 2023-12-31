﻿using Football.Context;
using Football.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football.Controllers
{
    public class PlayerController : Controller
    {
        private readonly FootballDbContext _context;
        public PlayerController(FootballDbContext context)
        {
            _context = context;
        }

        public IActionResult AddPlayer(int countryId)
        {
            ViewData["CountryId"] = countryId;
            return View("CreatePlayerForm");
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(Player player)
        {
            try
            {
                if (player.Club == null)
                    player.Club = "-";
                //var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                //var error = errors[0]; 
                if (ModelState.IsValid)
                {
                    _context.Players.Add(player);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Details", "Home", new { countryId = player.CountryID });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> DeletePlayer(int playerId)
        {
            try
            {
                var player = await _context.Players.FindAsync(playerId);

                _context.Players.Remove(player);
                await _context.SaveChangesAsync();

                return RedirectToAction("Details", "Home", new { countryId = player.CountryID });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> EditPlayer(int playerId)
        {
            try
            {
                var currentPlayer = await _context.Players.FindAsync(playerId);
                return View("EditPlayerForm", currentPlayer);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
        [HttpPost]
        public async Task<IActionResult> SavePlayer(Player player)
        {
            try {
                if (ModelState.IsValid)
                {
                    if (player.Club == null)
                        player.Club = "-";

                    _context.Players.Update(player);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Details", "Home", new { countryId = player.CountryID });

                }

                // Jeśli walidacja nie powiodła się, ponownie wyświetlamy formularz z błędami
                return RedirectToAction("EditPlayer", player.PlayerID);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
        }
    }
}
