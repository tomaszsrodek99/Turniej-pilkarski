using Football.Context;
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

        public async Task<IActionResult> DeletePlayer(int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Home", new { id = player.CountryID });
        }

    }
}
