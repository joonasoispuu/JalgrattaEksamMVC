using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JalgrattaEksamMVC.Models;
using JalgrattaEksamMVC.Data;

namespace JalgrattaEksamMVC.Controllers
{
    public class JalgrattaeksamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JalgrattaeksamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jalgrattaeksams/Registreeri
        public IActionResult Registreeri()
        {
            return View();
        }

        // POST: Jalgrattaeksams/TeooriaTulemus
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TeooriaTulemus([Bind("Id,Teooriatulemus")] Jalgrattaeksam tulemus)
        {

            var Jalgrattaeksam = await _context.Jalgrattaeksam.FindAsync(tulemus.Id);
            if (Jalgrattaeksam == null)
            {
                return NotFound();
            }

            Jalgrattaeksam.Teooriatulemus = tulemus.Teooriatulemus;

            try
            {
                _context.Update(Jalgrattaeksam);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EksamExists(Jalgrattaeksam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Teooriatulemus));
        }


        // POST: Jalgrattaeksams/Registreeri
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registreeri([Bind("Id,Eesnimi,Perekonnanimi")] Jalgrattaeksam Jalgrattaeksam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Jalgrattaeksam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Jalgrattaeksam);
        }

        // GET: Jalgrattaeksams/Teooriatulemus
        public async Task<IActionResult> Teooriatulemus()
        {
            var model = _context.Jalgrattaeksam.Where(e => e.Teooriatulemus == -1);
            return View(await model.ToListAsync());
        }

        // GET: Jalgrattaeksams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jalgrattaeksam.ToListAsync());
        }

        // GET: Jalgrattaeksams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Jalgrattaeksam = await _context.Jalgrattaeksam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Jalgrattaeksam == null)
            {
                return NotFound();
            }

            return View(Jalgrattaeksam);
        }

        // GET: Jalgrattaeksams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jalgrattaeksams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Eesnimi,Perekonnanimi,Teooriatulemus,Slaalom,Ringtee,Tanav,Luba")] Jalgrattaeksam Jalgrattaeksam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Jalgrattaeksam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Jalgrattaeksam);
        }

        // GET: Jalgrattaeksams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Jalgrattaeksam = await _context.Jalgrattaeksam.FindAsync(id);
            if (Jalgrattaeksam == null)
            {
                return NotFound();
            }
            return View(Jalgrattaeksam);
        }

        // POST: Jalgrattaeksams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Eesnimi,Perekonnanimi,Teooriatulemus,Slaalom,Ringtee,Tanav,Luba")] Jalgrattaeksam Jalgrattaeksam)
        {
            if (id != Jalgrattaeksam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Jalgrattaeksam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EksamExists(Jalgrattaeksam.Id))
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
            return View(Jalgrattaeksam);
        }


        // GET: Jalgrattaeksams/Slaalom
        public async Task<IActionResult> Slaalom()
        {
            var model = _context.Jalgrattaeksam
                .Where(e => e.Teooriatulemus >= 9 && e.Slaalom == -1);
            return View(await model.ToListAsync());
        }

        // GET: Jalgrattaeksams/Ringtee
        public async Task<IActionResult> Ringtee()
        {
            var model = _context.Jalgrattaeksam
                .Where(e => e.Teooriatulemus >= 9 && e.Ringtee == -1);
            return View(await model.ToListAsync());
        }

        // GET: Jalgrattaeksams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Jalgrattaeksam = await _context.Jalgrattaeksam
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Jalgrattaeksam == null)
            {
                return NotFound();
            }

            return View(Jalgrattaeksam);
        }

        // POST: Jalgrattaeksams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Jalgrattaeksam = await _context.Jalgrattaeksam.FindAsync(id);
            _context.Jalgrattaeksam.Remove(Jalgrattaeksam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EksamExists(int id)
        {
            return _context.Jalgrattaeksam.Any(e => e.Id == id);
        }
    }
}
