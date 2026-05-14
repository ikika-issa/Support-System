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
    public class TicketTasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketTasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TicketTasks
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TicketTasks.Include(t => t.SupportGroup).Include(t => t.SupportSystemAppUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TicketTasks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketTask = await _context.TicketTasks
                .Include(t => t.SupportGroup)
                .Include(t => t.SupportSystemAppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketTask == null)
            {
                return NotFound();
            }

            return View(ticketTask);
        }

        // GET: TicketTasks/Create
        public IActionResult Create()
        {
            ViewData["SupportGroupId"] = new SelectList(_context.SupportGroups, "Id", "Id");
            ViewData["SupportSystemAppUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: TicketTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Status,Description,SupportGroupId,Priority,ScheduleStart,ScheduleEnd,SupportSystemAppUserId,TaskType,ActualStart,ActualEnd,Id")] TicketTask ticketTask)
        {
            if (ModelState.IsValid)
            {
                ticketTask.Id = Guid.NewGuid();
                _context.Add(ticketTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SupportGroupId"] = new SelectList(_context.SupportGroups, "Id", "Id", ticketTask.SupportGroupId);
            ViewData["SupportSystemAppUserId"] = new SelectList(_context.Users, "Id", "Id", ticketTask.SupportSystemAppUserId);
            return View(ticketTask);
        }

        // GET: TicketTasks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketTask = await _context.TicketTasks.FindAsync(id);
            if (ticketTask == null)
            {
                return NotFound();
            }
            ViewData["SupportGroupId"] = new SelectList(_context.SupportGroups, "Id", "Id", ticketTask.SupportGroupId);
            ViewData["SupportSystemAppUserId"] = new SelectList(_context.Users, "Id", "Id", ticketTask.SupportSystemAppUserId);
            return View(ticketTask);
        }

        // POST: TicketTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Title,Status,Description,SupportGroupId,Priority,ScheduleStart,ScheduleEnd,SupportSystemAppUserId,TaskType,ActualStart,ActualEnd,Id")] TicketTask ticketTask)
        {
            if (id != ticketTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketTaskExists(ticketTask.Id))
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
            ViewData["SupportGroupId"] = new SelectList(_context.SupportGroups, "Id", "Id", ticketTask.SupportGroupId);
            ViewData["SupportSystemAppUserId"] = new SelectList(_context.Users, "Id", "Id", ticketTask.SupportSystemAppUserId);
            return View(ticketTask);
        }

        // GET: TicketTasks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketTask = await _context.TicketTasks
                .Include(t => t.SupportGroup)
                .Include(t => t.SupportSystemAppUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketTask == null)
            {
                return NotFound();
            }

            return View(ticketTask);
        }

        // POST: TicketTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ticketTask = await _context.TicketTasks.FindAsync(id);
            if (ticketTask != null)
            {
                _context.TicketTasks.Remove(ticketTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketTaskExists(Guid id)
        {
            return _context.TicketTasks.Any(e => e.Id == id);
        }
    }
}
