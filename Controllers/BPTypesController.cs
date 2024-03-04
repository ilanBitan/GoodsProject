using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodsProject.Data;
using GoodsProject.Models;

namespace GoodsProject.Controllers
{
    public class BPTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BPTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BPTypes
        public async Task<IActionResult> Index()
        {
            return Json(await _context.BPType.ToListAsync());
        }

        // GET: BPTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPType = await _context.BPType
                .FirstOrDefaultAsync(m => m.TypeCode == id);
            if (bPType == null)
            {
                return NotFound();
            }

            return Json(bPType);
        }

        // GET: BPTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BPTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeCode,TypeName")] BPType bPType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bPType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bPType);
        }

        // GET: BPTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPType = await _context.BPType.FindAsync(id);
            if (bPType == null)
            {
                return NotFound();
            }
            return View(bPType);
        }

        // POST: BPTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TypeCode,TypeName")] BPType bPType)
        {
            if (id != bPType.TypeCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bPType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BPTypeExists(bPType.TypeCode))
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
            return View(bPType);
        }

        // GET: BPTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bPType = await _context.BPType
                .FirstOrDefaultAsync(m => m.TypeCode == id);
            if (bPType == null)
            {
                return NotFound();
            }

            return View(bPType);
        }

        // POST: BPTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var bPType = await _context.BPType.FindAsync(id);
            _context.BPType.Remove(bPType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BPTypeExists(string id)
        {
            return _context.BPType.Any(e => e.TypeCode == id);
        }
    }
}
