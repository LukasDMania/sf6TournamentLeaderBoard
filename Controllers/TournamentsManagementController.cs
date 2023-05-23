using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewLEaderboard.Models;

namespace NewLEaderboard.Controllers
{
    public class TournamentsManagementController : Controller
    {
        private readonly FgcBeTournamentDataContext _context;

        public TournamentsManagementController()
        {
            _context = new FgcBeTournamentDataContext();
        }

        // GET: TournamentManagement
        public async Task<IActionResult> Index()
        {

            var tourneys = await _context.Tournaments
                .Include(t => t.Results)
                .ToListAsync();
            foreach (var item in tourneys)
            {
                item.CalculateParticipantAmount();
            }
            _context.SaveChanges();

              return _context.Tournaments != null ? 
                          View(tourneys) :
                          Problem("Entity set 'FgcBeTournamentDataContext.Tournaments'  is null.");
        }

        // GET: TournamentManagement/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tournaments == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournaments
                .FirstOrDefaultAsync(m => m.TournamentId == id);
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // GET: TournamentManagement/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TournamentManagement/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TournamentId,TournamentName,TournamentVodUrl,ChallongeUrl, TournamentDate")] Tournament tournament)
        {
            
                tournament.NameDateDisplay();
                _context.Add(tournament);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: TournamentManagement/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tournaments == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament == null)
            {
                return NotFound();
            }
            return View(tournament);
        }

        // POST: TournamentManagement/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TournamentId,TournamentName,TournamentVodUrl,TournamentDate,ParticipantsAmount")] Tournament tournament)
        {
            if (id != tournament.TournamentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournament);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TournamentExists(tournament.TournamentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tournament);
        }

        // GET: TournamentManagement/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tournaments == null)
            {
                return NotFound();
            }

            var tournament = await _context.Tournaments
                .FirstOrDefaultAsync(m => m.TournamentId == id);
            if (tournament == null)
            {
                return NotFound();
            }

            return View(tournament);
        }

        // POST: TournamentManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tournaments == null)
            {
                return Problem("Entity set 'FgcBeTournamentDataContext.Tournaments'  is null.");
            }
            var tournament = await _context.Tournaments.FindAsync(id);
            if (tournament != null)
            {
                _context.Tournaments.Remove(tournament);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TournamentExists(int id)
        {
          return (_context.Tournaments?.Any(e => e.TournamentId == id)).GetValueOrDefault();
        }
    }
}
