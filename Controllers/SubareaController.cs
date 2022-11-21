using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaEmpleados.Data;
using SistemaEmpleados.Models;

namespace SistemaEmpleados.Controllers
{
    public class SubareaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubareaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subarea
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SubAreas.Include(s => s.Area);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subarea/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subarea = await _context.SubAreas
                .Include(s => s.Area)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subarea == null)
            {
                return NotFound();
            }

            return View(subarea);
        }

        // GET: Subarea/Create
        public IActionResult Create()
        {
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name");
            return View();
        }

        // POST: Subarea/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AreaId")] Subarea subarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name", subarea.AreaId);
            return View(subarea);
        }

        // GET: Subarea/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subarea = await _context.SubAreas.FindAsync(id);
            if (subarea == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name", subarea.AreaId);
            return View(subarea);
        }

        // POST: Subarea/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AreaId")] Subarea subarea)
        {
            if (id != subarea.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubareaExists(subarea.Id))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "Id", "Name", subarea.AreaId);
            return View(subarea);
        }

        // GET: Subarea/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subarea = await _context.SubAreas
                .Include(s => s.Area)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subarea == null)
            {
                return NotFound();
            }

            return View(subarea);
        }

        // POST: Subarea/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subarea = await _context.SubAreas.FindAsync(id);
            _context.SubAreas.Remove(subarea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubareaExists(int id)
        {
            return _context.SubAreas.Any(e => e.Id == id);
        }
    }
}
