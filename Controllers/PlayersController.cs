using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewLEaderboard.Models;

namespace NewLEaderboard.Controllers
{
    public class PlayersController : Controller
    {
        private readonly FgcBeTournamentDataContext _context;

        public PlayersController()
        {
            _context = new FgcBeTournamentDataContext();
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            try
            {
                var players = await _context.Players.Include(p => p.Results).ToListAsync();


                foreach (var player in players)
                {
                    player.TotalPoints = player.CalculateTotalPoints();
                    player.CalculateTotalTopThree();
                    player.WeeksCompeted = player.CalculateTotalWeeksCompeted();
                }
                _context.SaveChanges();


                var playersSorted = players.OrderByDescending(p => p.TotalPoints);
                return _context.Players != null ?
                              View(playersSorted) :
                              Problem("Entity set 'FgcBeTournamentDataContext.Players'  is null.");
            }
            catch (Exception)
            {
                return RedirectToAction("Error");
            }
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Players == null)
            {
                return NotFound();
            }

            var player = await _context.Players
            .Include(p => p.Results)
                .ThenInclude(r => r.Tournament)
            .FirstOrDefaultAsync(p => p.PlayerId == id);


            if (player == null)
            {
                return NotFound();
            }


            return View(player);
        }

        private bool PlayerExists(int id)
        {
          return (_context.Players?.Any(e => e.PlayerId == id)).GetValueOrDefault();
        }
    }
}
