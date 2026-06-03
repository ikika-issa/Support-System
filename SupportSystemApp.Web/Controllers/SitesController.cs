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
    public class SitesController : Controller
    {
        private readonly ISiteService _siteService;

        public SitesController(ISiteService siteService)
        {
            _siteService = siteService;
        } 

        // GET: Sites
        public IActionResult Index()
        {
            var sites = _siteService.GetAll();
            return View(sites);
        }

        // GET: Sites/Details/5
        public IActionResult Details(Guid id)
        {
            var site = _siteService.GetById(id);
            if (site  == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // GET: Sites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Location,Id")] Site site)
        {
            if (ModelState.IsValid)
            {
                _siteService.Insert(site);

                return RedirectToAction(nameof(Index));
            }
            return View(site);
        }

        // GET: Sites/Edit/5
        public IActionResult Edit(Guid id)
        {
            var site = _siteService.GetById(id);
            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,Location,Id")] Site site)
        {
            if (id != site.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _siteService.Update(site);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteExists(site.Id))
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
            return View(site);
        }

        // GET: Sites/Delete/5
        public IActionResult Delete(Guid id)
        {
            var site = _siteService.GetById(id);

            if (site == null)
            {
                return NotFound();
            }

            return View(site);
        }

        // POST: Sites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var site = _siteService.GetById(id);

            if (site != null)
            {
                _siteService.DeleteById(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SiteExists(Guid id)
        {
            return _siteService.GetById(id) != null;
        }
    }
}
