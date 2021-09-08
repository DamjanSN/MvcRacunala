using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcRacunala.Data;
using MvcRacunala.Models;

namespace MvcRacunala.Controllers
{


    public class RacunalasController : Controller
    {
        private readonly MvcRacunalaContext _context;

        public RacunalasController(MvcRacunalaContext context)
        {
            _context = context;
        }

        // GET: Racunalas
        public async Task<IActionResult> Index(string searchString)
        {
            var Racunala = from m in _context.Racunala
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                Racunala = Racunala.Where(s => s.Naziv.Contains(searchString));
            }

            return View(await Racunala.ToListAsync());
        }


        // GET: Racunalas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racunala = await _context.Racunala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racunala == null)
            {
                return NotFound();
            }

            return View(racunala);
        }

        // GET: Racunalas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Racunalas/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naziv,DatumIzdavanja,Vrsta,Cijena,Stanje")] Racunala racunala)
        {
            if (ModelState.IsValid)
            {
                _context.Add(racunala);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(racunala);
        }

        // GET: Racunalas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racunala = await _context.Racunala.FindAsync(id);
            if (racunala == null)
            {
                return NotFound();
            }
            return View(racunala);
        }

        // POST: Racunalas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naziv,DatumIzdavanja,Vrsta,Cijena,Stanje")] Racunala racunala)
        {
            if (id != racunala.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(racunala);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RacunalaExists(racunala.Id))
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
            return View(racunala);
        }

        // GET: Racunalas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var racunala = await _context.Racunala
                .FirstOrDefaultAsync(m => m.Id == id);
            if (racunala == null)
            {
                return NotFound();
            }

            return View(racunala);
        }

        // POST: Racunalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var racunala = await _context.Racunala.FindAsync(id);
            _context.Racunala.Remove(racunala);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RacunalaExists(int id)
        {
            return _context.Racunala.Any(e => e.Id == id);
        }
    }
}

