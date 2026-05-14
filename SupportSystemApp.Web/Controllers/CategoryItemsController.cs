using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Repository;

namespace SupportSystemApp.Web.Controllers
{
    public class CategoryItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CategoryItems.Include(c => c.Subcategory);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CategoryItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryItem = await _context.CategoryItems
                .Include(c => c.Subcategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryItem == null)
            {
                return NotFound();
            }

            return View(categoryItem);
        }

        // GET: CategoryItems/Create
        public IActionResult Create()
        {
            ViewData["SubcategoryId"] = new SelectList(_context.SubCategories, "Id", "Id");
            return View();
        }

        // POST: CategoryItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,SubcategoryId,Id")] CategoryItem categoryItem)
        {
            if (ModelState.IsValid)
            {
                categoryItem.Id = Guid.NewGuid();
                _context.Add(categoryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubcategoryId"] = new SelectList(_context.SubCategories, "Id", "Id", categoryItem.SubcategoryId);
            return View(categoryItem);
        }

        // GET: CategoryItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryItem = await _context.CategoryItems.FindAsync(id);
            if (categoryItem == null)
            {
                return NotFound();
            }
            ViewData["SubcategoryId"] = new SelectList(_context.SubCategories, "Id", "Id", categoryItem.SubcategoryId);
            return View(categoryItem);
        }

        // POST: CategoryItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,SubcategoryId,Id")] CategoryItem categoryItem)
        {
            if (id != categoryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryItemExists(categoryItem.Id))
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
            ViewData["SubcategoryId"] = new SelectList(_context.SubCategories, "Id", "Id", categoryItem.SubcategoryId);
            return View(categoryItem);
        }

        // GET: CategoryItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryItem = await _context.CategoryItems
                .Include(c => c.Subcategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryItem == null)
            {
                return NotFound();
            }

            return View(categoryItem);
        }

        // POST: CategoryItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var categoryItem = await _context.CategoryItems.FindAsync(id);
            if (categoryItem != null)
            {
                _context.CategoryItems.Remove(categoryItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryItemExists(Guid id)
        {
            return _context.CategoryItems.Any(e => e.Id == id);
        }
    }
}
