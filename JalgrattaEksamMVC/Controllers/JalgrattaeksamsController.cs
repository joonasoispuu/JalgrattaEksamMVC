using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JalgrattaEksamMVC.Models;

namespace JalgrattaEksamMVC.Controllers
{
    public class JalgrattaeksamsController : Controller
    {
        private readonly JalgrattaeksamContext _context;

        public JalgrattaeksamsController(JalgrattaeksamContext context)
        {
            _context = context;
        }

        // GET: Jalgrattaeksams
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jalgrattaeksams.ToListAsync());
        }

        // GET: Jalgrattaeksams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jalgrattaeksam = await _context.Jalgrattaeksams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jalgrattaeksam == null)
            {
                return NotFound();
            }

            return View(jalgrattaeksam);
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
        public async Task<IActionResult> Create([Bind("Id,Eesnimi,Perekonnanimi,Teooriatulemus,Slaalom,Ringtee,Tanav,Luba")] Jalgrattaeksam jalgrattaeksam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jalgrattaeksam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jalgrattaeksam);
        }

        // GET: Jalgrattaeksams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jalgrattaeksam = await _context.Jalgrattaeksams.FindAsync(id);
            if (jalgrattaeksam == null)
            {
                return NotFound();
            }
            return View(jalgrattaeksam);
        }

        // POST: Jalgrattaeksams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Eesnimi,Perekonnanimi,Teooriatulemus,Slaalom,Ringtee,Tanav,Luba")] Jalgrattaeksam jalgrattaeksam)
        {
            if (id != jalgrattaeksam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jalgrattaeksam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JalgrattaeksamExists(jalgrattaeksam.Id))
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
            return View(jalgrattaeksam);
        }

        // GET: Jalgrattaeksams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jalgrattaeksam = await _context.Jalgrattaeksams
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jalgrattaeksam == null)
            {
                return NotFound();
            }

            return View(jalgrattaeksam);
        }

        // POST: Jalgrattaeksams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jalgrattaeksam = await _context.Jalgrattaeksams.FindAsync(id);
            _context.Jalgrattaeksams.Remove(jalgrattaeksam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JalgrattaeksamExists(int id)
        {
            return _context.Jalgrattaeksams.Any(e => e.Id == id);
        }
    }
}
