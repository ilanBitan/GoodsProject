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
    public class SaleOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaleOrders
        public async Task<IActionResult> Index()
        {
            return Json(await _context.SaleOrder.ToListAsync());
        }

        // GET: SaleOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .FirstOrDefaultAsync(m => m.ID == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return Json(saleOrder);
        }

        // GET: SaleOrders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,BPCode,CreateDate,LastUpdateDate,CreatedBy,LastUpdatedBy")] SaleOrder saleOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleOrder);
        }

        // GET: SaleOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder.FindAsync(id);
            if (saleOrder == null)
            {
                return NotFound();
            }
            return View(saleOrder);
        }

        // POST: SaleOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,BPCode,CreateDate,LastUpdateDate,CreatedBy,LastUpdatedBy")] SaleOrder saleOrder)
        {
            if (id != saleOrder.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleOrderExists(saleOrder.ID))
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
            return View(saleOrder);
        }

        // GET: SaleOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrder = await _context.SaleOrder
                .FirstOrDefaultAsync(m => m.ID == id);
            if (saleOrder == null)
            {
                return NotFound();
            }

            return View(saleOrder);
        }

        // POST: SaleOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleOrder = await _context.SaleOrder.FindAsync(id);
            _context.SaleOrder.Remove(saleOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleOrderExists(int id)
        {
            return _context.SaleOrder.Any(e => e.ID == id);
        }
    }
}
