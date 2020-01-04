using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FarulewskiKlinika.DataContext;
using FarulewskiKlinika.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarulewskiKlinika.Controllers
{
    public class LekarzController : Controller
    {
            private readonly ApplicationDbContext _context;

        public LekarzController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lekarze
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lekarze.ToListAsync());
        }

        // GET: Lekarze/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lekarz = await _context.Lekarze
                .FirstOrDefaultAsync(m => m.LekarzID == id);
            if (lekarz == null)
            {
                return NotFound();
            }

            return View(lekarz);
        }

        // GET: Lekarze/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lekarze/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LekarzID,Imie,Nazwisko,Specjalizacja,Email")] Lekarz lekarz)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lekarz);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lekarz);
        }

        // GET: Lekarze/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lekarz = await _context.Lekarze.FindAsync(id);
            if (lekarz == null)
            {
                return NotFound();
            }
            return View(lekarz);
        }

        // POST: Lekarze/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LekarzID,Imie,Nazwisko,Specjalizacja,Email")] Lekarz lekarz)
        {
            if (id != lekarz.LekarzID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lekarz);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LekarzExists(lekarz.LekarzID))
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
            return View(lekarz);
        }

        // GET: Lekarze/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lekarz = await _context.Lekarze
                .FirstOrDefaultAsync(m => m.LekarzID == id);
            if (lekarz == null)
            {
                return NotFound();
            }

            return View(lekarz);
        }

        // POST: Lekarze/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lekarz = await _context.Lekarze.FindAsync(id);
            _context.Lekarze.Remove(lekarz);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LekarzExists(int id)
        {
            return _context.Lekarze.Any(e => e.LekarzID == id);
        }
    }
}
