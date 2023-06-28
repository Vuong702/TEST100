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
    public class NVVBNController : Controller
    {
        private readonly BT _context;

        public NVVBNController(BT context)
        {
            _context = context;
        }

        // GET: NVVBN
        public async Task<IActionResult> Index()
        {
              return _context.NVVBN != null ? 
                          View(await _context.NVVBN.ToListAsync()) :
                          Problem("Entity set 'BT.NVVBN'  is null.");
        }

        // GET: NVVBN/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NVVBN == null)
            {
                return NotFound();
            }

            var nVVBN = await _context.NVVBN
                .FirstOrDefaultAsync(m => m.Quequan == id);
            if (nVVBN == null)
            {
                return NotFound();
            }

            return View(nVVBN);
        }

        // GET: NVVBN/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NVVBN/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Quequan,Ten")] NVVBN nVVBN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nVVBN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nVVBN);
        }

        // GET: NVVBN/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NVVBN == null)
            {
                return NotFound();
            }

            var nVVBN = await _context.NVVBN.FindAsync(id);
            if (nVVBN == null)
            {
                return NotFound();
            }
            return View(nVVBN);
        }

        // POST: NVVBN/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Quequan,Ten")] NVVBN nVVBN)
        {
            if (id != nVVBN.Quequan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nVVBN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NVVBNExists(nVVBN.Quequan))
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
            return View(nVVBN);
        }

        // GET: NVVBN/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NVVBN == null)
            {
                return NotFound();
            }

            var nVVBN = await _context.NVVBN
                .FirstOrDefaultAsync(m => m.Quequan == id);
            if (nVVBN == null)
            {
                return NotFound();
            }

            return View(nVVBN);
        }

        // POST: NVVBN/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NVVBN == null)
            {
                return Problem("Entity set 'BT.NVVBN'  is null.");
            }
            var nVVBN = await _context.NVVBN.FindAsync(id);
            if (nVVBN != null)
            {
                _context.NVVBN.Remove(nVVBN);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NVVBNExists(string id)
        {
          return (_context.NVVBN?.Any(e => e.Quequan == id)).GetValueOrDefault();
        }
    }
}
