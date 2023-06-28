using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TEST100.Models;

namespace TEST100.Controllers
{
    public class NVVHNController : Controller
    {
        private readonly BT _context;

        public NVVHNController(BT context)
        {
            _context = context;
        }

        // GET: NVVHN
        public async Task<IActionResult> Index()
        {
            var bT = _context.NVVHN.Include(n => n.NVVBN);
            return View(await bT.ToListAsync());
        }

        // GET: NVVHN/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NVVHN == null)
            {
                return NotFound();
            }

            var nVVHN = await _context.NVVHN
                .Include(n => n.NVVBN)
                .FirstOrDefaultAsync(m => m.Quequan == id);
            if (nVVHN == null)
            {
                return NotFound();
            }

            return View(nVVHN);
        }

        // GET: NVVHN/Create
        public IActionResult Create()
        {
            ViewData["Quequan"] = new SelectList(_context.NVVBN, "Quequan", "Quequan");
            return View();
        }

        // POST: NVVHN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Quequan,NGo,Sonha")] NVVHN nVVHN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nVVHN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Quequan"] = new SelectList(_context.NVVBN, "Quequan", "Quequan", nVVHN.Quequan);
            return View(nVVHN);
        }

        // GET: NVVHN/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NVVHN == null)
            {
                return NotFound();
            }

            var nVVHN = await _context.NVVHN.FindAsync(id);
            if (nVVHN == null)
            {
                return NotFound();
            }
            ViewData["Quequan"] = new SelectList(_context.NVVBN, "Quequan", "Quequan", nVVHN.Quequan);
            return View(nVVHN);
        }

        // POST: NVVHN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Quequan,NGo,Sonha")] NVVHN nVVHN)
        {
            if (id != nVVHN.Quequan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nVVHN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NVVHNExists(nVVHN.Quequan))
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
            ViewData["Quequan"] = new SelectList(_context.NVVBN, "Quequan", "Quequan", nVVHN.Quequan);
            return View(nVVHN);
        }

        // GET: NVVHN/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NVVHN == null)
            {
                return NotFound();
            }

            var nVVHN = await _context.NVVHN
                .Include(n => n.NVVBN)
                .FirstOrDefaultAsync(m => m.Quequan == id);
            if (nVVHN == null)
            {
                return NotFound();
            }

            return View(nVVHN);
        }

        // POST: NVVHN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NVVHN == null)
            {
                return Problem("Entity set 'BT.NVVHN'  is null.");
            }
            var nVVHN = await _context.NVVHN.FindAsync(id);
            if (nVVHN != null)
            {
                _context.NVVHN.Remove(nVVHN);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NVVHNExists(string id)
        {
          return (_context.NVVHN?.Any(e => e.Quequan == id)).GetValueOrDefault();
        }
    }
}
