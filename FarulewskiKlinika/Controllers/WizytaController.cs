using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarulewskiKlinika.DataContext;
using FarulewskiKlinika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace FarulewskiKlinika.Controllers
{
    public class WizytaController : Controller
    {
        // dependency injection, czyli w konstruktorze przekazujemy żeby korzystac z contextu czyli bd
        private readonly ApplicationDbContext _context;

        public WizytaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Wizyta
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Wizyty.Include(w => w.Lekarz).Include(w => w.Pacjent);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Wizytas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wizyta = await _context.Wizyty
                .Include(w => w.Lekarz)
                .Include(w => w.Pacjent)
                .FirstOrDefaultAsync(m => m.WizytaID == id);
            if (wizyta == null)
            {
                return NotFound();
            }

            return View(wizyta);
        }

        // GET: Wizyta/Create
        public IActionResult Create()
        {
            ViewData["LekarzID"] = new SelectList(_context.Pracownicy, "PracownikID", "Email");
            ViewData["PacjentID"] = new SelectList(_context.Pacjenci, "PacjentID", "Email");




            return View();
        }

        // POST: Wizyta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WizytaID,PacjentID,LekarzID,Specjalizacja,DataWizyty,Zalecenia")] Wizyta wizyta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wizyta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LekarzID"] = new SelectList(_context.Pracownicy, "PracownikID", "Email", wizyta.LekarzID);
            ViewData["PacjentID"] = new SelectList(_context.Pacjenci, "PacjentID", "Email", wizyta.PacjentID);
            return View(wizyta);
        }

        // GET: Wizyta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wizyta = await _context.Wizyty.FindAsync(id);
            if (wizyta == null)
            {
                return NotFound();
            }
            ViewData["LekarzID"] = new SelectList(_context.Pracownicy, "PracownikID", "Email", wizyta.LekarzID);
            ViewData["PacjentID"] = new SelectList(_context.Pacjenci, "PacjentID", "Email", wizyta.PacjentID);
            return View(wizyta);
        }

        // POST: Wizyta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WizytaID,PacjentID,LekarzID,Specjalizacja,DataWizyty,Zalecenia")] Wizyta wizyta)
        {
            if (id != wizyta.WizytaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wizyta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WizytaExists(wizyta.WizytaID))
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
            ViewData["LekarzID"] = new SelectList(_context.Pracownicy, "PracownikID", "Email", wizyta.LekarzID);
            ViewData["PacjentID"] = new SelectList(_context.Pacjenci, "PacjentID", "Email", wizyta.PacjentID);
            return View(wizyta);
        }

        // GET: Wizyta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wizyta = await _context.Wizyty
                .Include(w => w.Lekarz)
                .Include(w => w.Pacjent)
                .FirstOrDefaultAsync(m => m.WizytaID == id);
            if (wizyta == null)
            {
                return NotFound();
            }

            return View(wizyta);
        }

        // POST: Wizyta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wizyta = await _context.Wizyty.FindAsync(id);
            _context.Wizyty.Remove(wizyta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WizytaExists(int id)
        {
            return _context.Wizyty.Any(e => e.WizytaID == id);
        }
    }
}
