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
    public class PurchaseOrderLinesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderLinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrderLines
        public async Task<IActionResult> Index()
        {
            return Json(await _context.PurchaseOrderLine.ToListAsync());
        }

        // GET: PurchaseOrderLines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderLine = await _context.PurchaseOrderLine
                .FirstOrDefaultAsync(m => m.LineID == id);
            if (purchaseOrderLine == null)
            {
                return NotFound();
            }

            return Json(purchaseOrderLine);
        }

        // GET: PurchaseOrderLines/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PurchaseOrderLines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LineID,DocID,ItemCode,Quantity,CreateDate,LastUpdateDate,CreatedBy,LastUpdatedBy")] PurchaseOrderLine purchaseOrderLine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrderLine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseOrderLine);
        }

        // GET: PurchaseOrderLines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderLine = await _context.PurchaseOrderLine.FindAsync(id);
            if (purchaseOrderLine == null)
            {
                return NotFound();
            }
            return View(purchaseOrderLine);
        }

        // POST: PurchaseOrderLines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LineID,DocID,ItemCode,Quantity,CreateDate,LastUpdateDate,CreatedBy,LastUpdatedBy")] PurchaseOrderLine purchaseOrderLine)
        {
            if (id != purchaseOrderLine.LineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrderLine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderLineExists(purchaseOrderLine.LineID))
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
            return View(purchaseOrderLine);
        }

        // GET: PurchaseOrderLines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderLine = await _context.PurchaseOrderLine
                .FirstOrDefaultAsync(m => m.LineID == id);
            if (purchaseOrderLine == null)
            {
                return NotFound();
            }

            return View(purchaseOrderLine);
        }

        // POST: PurchaseOrderLines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrderLine = await _context.PurchaseOrderLine.FindAsync(id);
            _context.PurchaseOrderLine.Remove(purchaseOrderLine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderLineExists(int id)
        {
            return _context.PurchaseOrderLine.Any(e => e.LineID == id);
        }
    }
}
