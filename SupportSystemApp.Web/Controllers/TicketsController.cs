using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Repository;
using SupportSystemApp.Service.Interface;

namespace SupportSystemApp.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // GET: Tickets
        public IActionResult Index()
        {
            return View(_ticketService.GetAll());
        }

        // GET: Tickets/Details/5
        public IActionResult Details(Guid id)
        {
            var ticket = _ticketService.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TicketNumber,Header,Details,Status,Priority,CreatedAt,DueBy,ResolvedAt,RequesterId,TechnitianId,SiteId,SupportGroupId,Id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _ticketService.Insert(ticket);
                return RedirectToAction(nameof(Index));
            }

            //ViewBag.Technitians = new SelectList(_ticketService.GetAll()
            //    .Select(c => new SelectListItem
            //    {
            //        Value = c.Id.ToString(),
            //        //TO DO
            //        Text = c.
            //    })
            //    .ToList();

            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["TechnitianId"] = new SelectList(_context.Users, "Id", "Id", ticket.TechnitianId);
            ViewData["RequesterId"] = new SelectList(_context.Users, "Id", "Id", ticket.RequesterId);
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Id", ticket.SiteId);
            ViewData["SupportGroupId"] = new SelectList(_context.SupportGroups, "Id", "Id", ticket.SupportGroupId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TicketNumber,Header,Details,Status,Priority,CreatedAt,DueBy,ResolvedAt,RequesterId,TechnitianId,SiteId,SupportGroupId,Id")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            ViewData["TechnitianId"] = new SelectList(_context.Users, "Id", "Id", ticket.TechnitianId);
            ViewData["RequesterId"] = new SelectList(_context.Users, "Id", "Id", ticket.RequesterId);
            ViewData["SiteId"] = new SelectList(_context.Sites, "Id", "Id", ticket.SiteId);
            ViewData["SupportGroupId"] = new SelectList(_context.SupportGroups, "Id", "Id", ticket.SupportGroupId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.AssignedTo)
                .Include(t => t.OpenedBy)
                .Include(t => t.Site)
                .Include(t => t.SupportGroup)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
