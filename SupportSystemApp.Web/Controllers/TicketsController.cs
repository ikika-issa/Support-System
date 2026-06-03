using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Identity;
using SupportSystemApp.Repository;
using SupportSystemApp.Service.Interface;

namespace SupportSystemApp.Web.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly ISiteService _siteService;
        private readonly ISupportGroupService _supportGroupService;
        private readonly UserManager<SupportSystemAppUser> _userManager;

        public TicketsController(ITicketService ticketService, ISiteService siteService, 
            ISupportGroupService supportGroupService, UserManager<SupportSystemAppUser> userManager)
        {
            _ticketService = ticketService;
            _siteService = siteService;
            _supportGroupService = supportGroupService;
            _userManager = userManager;
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


            ViewBag.Sites = _siteService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            ViewBag.SupportGroups = _supportGroupService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            ViewBag.Users = _userManager.Users
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName
                })
                .ToList();

            ViewBag.Priorities = Enum.GetValues(typeof(TicketPriority))
                .Cast<TicketPriority>()
                .Select(p => new SelectListItem
                {
                    Value = p.ToString(),
                    Text = p.ToString()
                })
                .ToList();

            ViewBag.Statuses = Enum.GetValues(typeof(TicketStatus))
                .Cast<TicketStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                })
                .ToList();

            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public IActionResult Edit(Guid id)
        {
            var ticket = _ticketService.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            ViewBag.Sites = _siteService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            ViewBag.SupportGroups = _supportGroupService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            ViewBag.Users = _userManager.Users
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName
                })
                .ToList();

            ViewBag.Priorities = Enum.GetValues(typeof(TicketPriority))
                .Cast<TicketPriority>()
                .Select(p => new SelectListItem
                {
                    Value = p.ToString(),
                    Text = p.ToString()
                })
                .ToList();

            ViewBag.Statuses = Enum.GetValues(typeof(TicketStatus))
                .Cast<TicketStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                })
                .ToList();

            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("TicketNumber,Header,Details,Status,Priority,CreatedAt,DueBy,ResolvedAt,RequesterId,TechnitianId,SiteId,SupportGroupId,Id")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketService.Update(ticket);
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
            ViewBag.Sites = _siteService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            ViewBag.SupportGroups = _supportGroupService.GetAll()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();

            ViewBag.Users = _userManager.Users
                .Select(u => new SelectListItem
                {
                    Value = u.Id.ToString(),
                    Text = u.UserName
                })
                .ToList();

            ViewBag.Priorities = Enum.GetValues(typeof(TicketPriority))
                .Cast<TicketPriority>()
                .Select(p => new SelectListItem
                {
                    Value = p.ToString(),
                    Text = p.ToString()
                })
                .ToList();

            ViewBag.Statuses = Enum.GetValues(typeof(TicketStatus))
                .Cast<TicketStatus>()
                .Select(s => new SelectListItem
                {
                    Value = s.ToString(),
                    Text = s.ToString()
                })
                .ToList();
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public IActionResult Delete(Guid id)
        {
            var ticket = _ticketService.GetById(id);

            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var ticket = _ticketService.GetById(id);

            if (ticket != null)
            {
                _ticketService.DeleteById(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return _ticketService.GetById(id) != null;
        }
    }
}
