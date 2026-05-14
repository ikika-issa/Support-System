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
    public class SupportGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupportGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SupportGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.SupportGroups.ToListAsync());
        }

        // GET: SupportGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportGroup = await _context.SupportGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportGroup == null)
            {
                return NotFound();
            }

            return View(supportGroup);
        }

        // GET: SupportGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] SupportGroup supportGroup)
        {
            if (ModelState.IsValid)
            {
                supportGroup.Id = Guid.NewGuid();
                _context.Add(supportGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportGroup);
        }

        // GET: SupportGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportGroup = await _context.SupportGroups.FindAsync(id);
            if (supportGroup == null)
            {
                return NotFound();
            }
            return View(supportGroup);
        }

        // POST: SupportGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] SupportGroup supportGroup)
        {
            if (id != supportGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportGroupExists(supportGroup.Id))
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
            return View(supportGroup);
        }

        // GET: SupportGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportGroup = await _context.SupportGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supportGroup == null)
            {
                return NotFound();
            }

            return View(supportGroup);
        }

        // POST: SupportGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var supportGroup = await _context.SupportGroups.FindAsync(id);
            if (supportGroup != null)
            {
                _context.SupportGroups.Remove(supportGroup);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportGroupExists(Guid id)
        {
            return _context.SupportGroups.Any(e => e.Id == id);
        }
    }
}
