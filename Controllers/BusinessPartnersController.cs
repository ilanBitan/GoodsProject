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
    public class BusinessPartnersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BusinessPartnersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BusinessPartners
        public async Task<IActionResult> Index()
        {
            return Json(await _context.BusinessPartner.ToListAsync());
        }

        // GET: BusinessPartners/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessPartner = await _context.BusinessPartner
                .FirstOrDefaultAsync(m => m.BPCode == id);
            if (businessPartner == null)
            {
                return NotFound();
            }

            return Json(businessPartner);
        }

        // GET: BusinessPartners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BusinessPartners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BPCode,BPName,BPType,Active")] BusinessPartner businessPartner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessPartner);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessPartner);
        }

        // GET: BusinessPartners/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessPartner = await _context.BusinessPartner.FindAsync(id);
            if (businessPartner == null)
            {
                return NotFound();
            }
            return View(businessPartner);
        }

        // POST: BusinessPartners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BPCode,BPName,BPType,Active")] BusinessPartner businessPartner)
        {
            if (id != businessPartner.BPCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessPartner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusinessPartnerExists(businessPartner.BPCode))
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
            return View(businessPartner);
        }

        // GET: BusinessPartners/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessPartner = await _context.BusinessPartner
                .FirstOrDefaultAsync(m => m.BPCode == id);
            if (businessPartner == null)
            {
                return NotFound();
            }

            return View(businessPartner);
        }

        // POST: BusinessPartners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var businessPartner = await _context.BusinessPartner.FindAsync(id);
            _context.BusinessPartner.Remove(businessPartner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BusinessPartnerExists(string id)
        {
            return _context.BusinessPartner.Any(e => e.BPCode == id);
        }
    }
}
