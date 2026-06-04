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
    public class NotesController : Controller
    {
        private readonly INoteService _noteService;
        private readonly UserManager<SupportSystemAppUser> _userManager;
        private readonly ITicketService _ticketService;

        public NotesController(INoteService noteService, UserManager<SupportSystemAppUser> userManager,
            ITicketService ticketService)
        {
            _noteService = noteService;
            _userManager = userManager;
            _ticketService = ticketService;
        }

        public IActionResult Index(Guid ticketId)
        {
            return View(_noteService.GetByTicket(ticketId));
        }

        // GET: Notes/Details/5
        public IActionResult Details(Guid id)
        {
            var note = _noteService.GetById(id);

            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Description,Id")] Note note, Guid ticketId)
        {
            if (ModelState.IsValid)
            {
                note.OpenedByUserId = _userManager.GetUserId(User);
                var ticket = _ticketService.GetById(ticketId);

                if (ticket == null)
                {
                    return NotFound();
                }


                _noteService.Insert(note, ticketId);

                return RedirectToAction(nameof(Index));
            }

            return View(note);
        }

        public IActionResult Edit(Guid id)
        {
            var note = _noteService.GetById(id);

            if (note == null)
            {
                return NotFound();
            }

            return View(note);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Description,Id")] Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _noteService.Update(note);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.Id))
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
            
            return View(note);
        }

        private bool NoteExists(Guid id)
        {
            return _noteService.GetById(id) != null;
        }
    }
}
