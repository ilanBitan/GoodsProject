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
    public class SaleOrderLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleOrderLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaleOrderLines
        public async Task<IActionResult> Index()
        {
            return Json(await _context.SaleOrderLine.ToListAsync());
        }

        // GET: SaleOrderLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrderLine = await _context.SaleOrderLine
                .FirstOrDefaultAsync(m => m.LineID == id);
            if (saleOrderLine == null)
            {
                return NotFound();
            }

            return Json(saleOrderLine);
        }

        // GET: SaleOrderLines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleOrderLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineID,DocID,ItemCode,Quantity,CreateDate,LastUpdateDate,CreatedBy,LastUpdatedBy")] SaleOrderLine saleOrderLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleOrderLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleOrderLine);
        }

        // GET: SaleOrderLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrderLine = await _context.SaleOrderLine.FindAsync(id);
            if (saleOrderLine == null)
            {
                return NotFound();
            }
            return View(saleOrderLine);
        }

        // POST: SaleOrderLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LineID,DocID,ItemCode,Quantity,CreateDate,LastUpdateDate,CreatedBy,LastUpdatedBy")] SaleOrderLine saleOrderLine)
        {
            if (id != saleOrderLine.LineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleOrderLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleOrderLineExists(saleOrderLine.LineID))
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
            return View(saleOrderLine);
        }

        // GET: SaleOrderLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrderLine = await _context.SaleOrderLine
                .FirstOrDefaultAsync(m => m.LineID == id);
            if (saleOrderLine == null)
            {
                return NotFound();
            }

            return View(saleOrderLine);
        }

        // POST: SaleOrderLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleOrderLine = await _context.SaleOrderLine.FindAsync(id);
            _context.SaleOrderLine.Remove(saleOrderLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleOrderLineExists(int id)
        {
            return _context.SaleOrderLine.Any(e => e.LineID == id);
        }
    }
}
