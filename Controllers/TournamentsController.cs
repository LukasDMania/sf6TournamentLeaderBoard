using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewLEaderboard.Models;

namespace NewLEaderboard.Controllers
{
    public class TournamentsController : Controller
    {
        private readonly FgcBeTournamentDataContext _context;

        public TournamentsController()
        {
            _context = new FgcBeTournamentDataContext();
        }

        // GET: Tournaments
        public async Task<IActionResult> Index()
        {

            try
            {
                var tournaments = await _context.Tournaments
                    .Include(p => p.Results)
                        .ToListAsync();

                foreach (var tournament in tournaments)
                {
                    tournament.CalculateParticipantAmount();
                }
                _context.SaveChanges();

                return _context.Tournaments != null ?
                            View(tournaments) :
                            Problem("Entity set 'FgcBeTournamentDataContext.Tournaments'  is null.");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET: Tournaments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null || _context.Tournaments == null)
                {
                    return NotFound();
                }

                var tournament = await _context.Tournaments
                    .FirstOrDefaultAsync(m => m.TournamentId == id);

                var participantsAmount = await _context.Results
                    .CountAsync(r => r.TournamentId == tournament.TournamentId);

                tournament.ParticipantsAmount = participantsAmount;

                ViewBag.participantsList = await _context.Results
                    .Include(r => r.Player)
                .Where(r => r.TournamentId == tournament.TournamentId)

                .ToListAsync();


                if (tournament == null)
                {
                    return NotFound();
                }

                return View(tournament);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        private bool TournamentExists(int id)
        {
          return (_context.Tournaments?.Any(e => e.TournamentId == id)).GetValueOrDefault();
        }
    }
}
