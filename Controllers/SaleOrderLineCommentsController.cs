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
    public class SaleOrderLineCommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaleOrderLineCommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SaleOrderLineComments
        public async Task<IActionResult> Index()
        {
            return Json(await _context.SaleOrderLineComment.ToListAsync());
        }

        // GET: SaleOrderLineComments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrderLineComment = await _context.SaleOrderLineComment
                .FirstOrDefaultAsync(m => m.CommentLineID == id);
            if (saleOrderLineComment == null)
            {
                return NotFound();
            }

            return Json(saleOrderLineComment);
        }

        // GET: SaleOrderLineComments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleOrderLineComments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentLineID,DocID,LineID,Comment")] SaleOrderLineComment saleOrderLineComment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saleOrderLineComment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(saleOrderLineComment);
        }

        // GET: SaleOrderLineComments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrderLineComment = await _context.SaleOrderLineComment.FindAsync(id);
            if (saleOrderLineComment == null)
            {
                return NotFound();
            }
            return View(saleOrderLineComment);
        }

        // POST: SaleOrderLineComments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentLineID,DocID,LineID,Comment")] SaleOrderLineComment saleOrderLineComment)
        {
            if (id != saleOrderLineComment.CommentLineID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saleOrderLineComment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleOrderLineCommentExists(saleOrderLineComment.CommentLineID))
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
            return View(saleOrderLineComment);
        }

        // GET: SaleOrderLineComments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleOrderLineComment = await _context.SaleOrderLineComment
                .FirstOrDefaultAsync(m => m.CommentLineID == id);
            if (saleOrderLineComment == null)
            {
                return NotFound();
            }

            return View(saleOrderLineComment);
        }

        // POST: SaleOrderLineComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleOrderLineComment = await _context.SaleOrderLineComment.FindAsync(id);
            _context.SaleOrderLineComment.Remove(saleOrderLineComment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaleOrderLineCommentExists(int id)
        {
            return _context.SaleOrderLineComment.Any(e => e.CommentLineID == id);
        }
    }
}
