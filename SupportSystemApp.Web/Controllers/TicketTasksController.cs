using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Identity;
using SupportSystemApp.Repository;
using SupportSystemApp.Service.Implementation;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportSystemApp.Web.Controllers
{
    public class TicketTasksController : Controller
    {
        private readonly ITicketTaskService _ticketTaskService;
        private readonly ITicketService _ticketService;
        private readonly UserManager<SupportSystemAppUser> _userManager;
        private readonly ISupportGroupService _supportGroupService;

        public TicketTasksController(ITicketTaskService ticketTaskService, ITicketService ticketService
            , UserManager<SupportSystemAppUser> userManager, ISupportGroupService supportGroupService)
        {
            _ticketTaskService = ticketTaskService;
            _ticketService = ticketService;
            _userManager = userManager;
            _supportGroupService = supportGroupService;
        }

        public IActionResult Index(Guid ticketId)
        {
            return View(_ticketTaskService.GetAllTasksByTicketId(ticketId));
        }

        public IActionResult Details(Guid id)
        {
            var ticketTask = _ticketTaskService.GetById(id);

            if (ticketTask == null)
            {
                return NotFound();
            }

            return View(ticketTask);
        }


        public IActionResult Create()
        {
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


            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Title,Status,Description,SupportGroupId,Priority,ScheduleStart,ScheduleEnd,SupportSystemAppUserId,TaskType,ActualStart,ActualEnd,Id")] TicketTask ticketTask, Guid ticketId)
        {
            if (ModelState.IsValid)
            {
                _ticketTaskService.Insert(ticketTask, ticketId);

                return RedirectToAction(nameof(Index));
            }

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

            return View(ticketTask);
        }

        public IActionResult Edit(Guid id)
        {
            var ticketTask = _ticketTaskService.GetById(id);

            if (ticketTask == null)
            {
                return NotFound();
            }

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

            return View(ticketTask);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Title,Status,Description,SupportGroupId,Priority,ScheduleStart," +
            "ScheduleEnd,SupportSystemAppUserId,TaskType,ActualStart,ActualEnd,Id")] TicketTask ticketTask)
        {
            if (id != ticketTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketTaskService.Update(ticketTask);
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

            return View(ticketTask);
        }

        public IActionResult Delete(Guid id)
        {
            var ticketTask = _ticketTaskService.GetById(id);

            if (ticketTask == null)
            {
                return NotFound();
            }

            return View(ticketTask);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id, Guid ticketId)
        {
            var ticketTask = _ticketTaskService.GetById(id);

            if (ticketTask != null)
            {
                _ticketTaskService.Delete(id, ticketId);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TicketTaskExists(Guid id)
        {
            return _ticketTaskService.GetById(id) != null;
        }
    }
}
