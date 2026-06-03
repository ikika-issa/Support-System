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
    public class SupportGroupsController : Controller
    {
        private readonly ISupportGroupService _supportGroupService;

        public SupportGroupsController(ISupportGroupService supportGroupService)
        {
            _supportGroupService = supportGroupService;
        }

        // GET: SupportGroups
        public IActionResult Index()
        {
            var supportGroups = _supportGroupService.GetAll();
            return View(supportGroups);
        }

        // GET: SupportGroups/Details/5
        public IActionResult Details(Guid id)
        {
            var supportGroup = _supportGroupService.GetById(id);

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
        public IActionResult Create([Bind("Name,Id")] SupportGroup supportGroup)
        {
            if (ModelState.IsValid)
            {
                _supportGroupService.Insert(supportGroup);

                return RedirectToAction(nameof(Index));
            }
            return View(supportGroup);
        }

        // GET: SupportGroups/Edit/5
        public IActionResult Edit(Guid id)
        {
            var supportGroup = _supportGroupService.GetById(id);

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
        public IActionResult Edit(Guid id, [Bind("Name,Id")] SupportGroup supportGroup)
        {
            if (id != supportGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _supportGroupService.Update(supportGroup);
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
        public IActionResult Delete(Guid id)
        {
            var supportGroup = _supportGroupService.GetById(id);
            if (supportGroup == null)
            {
                return NotFound();
            }

            return View(supportGroup);
        }

        // POST: SupportGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var supportGroup = _supportGroupService.GetById(id);

            if (supportGroup != null)
            {
                _supportGroupService.Delete(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SupportGroupExists(Guid id)
        {
            return _supportGroupService.GetById(id) != null;
        }
    }
}
