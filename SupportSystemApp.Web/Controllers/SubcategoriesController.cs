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
    public class SubcategoriesController : Controller
    {
        private readonly ISubcategoryService _subcategoryService;
        private readonly ICategoryService _categoryService;

        public SubcategoriesController(ISubcategoryService subcategoryService, ICategoryService categoryService)
        {
            _subcategoryService = subcategoryService;
            _categoryService = categoryService;
        }

        // GET: Subcategories
        public IActionResult Index()
        {
            return View(_subcategoryService.GetAllByCategoryId(Guid.Empty));
        }

        // GET: Subcategories/Details/5
        public IActionResult Details(Guid id)
        {
            var subcategory = _subcategoryService.GetById(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        // GET: Subcategories/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Subcategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,CategoryId,Id")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                _subcategoryService.Insert(subcategory);

                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Edit/5
        public IActionResult Edit(Guid id)
        {
            var subcategory = _subcategoryService.GetById(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // POST: Subcategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("Name,CategoryId,Id")] Subcategory subcategory)
        {
            if (id != subcategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _subcategoryService.Update(subcategory);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoryExists(subcategory.Id))
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
            ViewData["CategoryId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Delete/5
        public IActionResult Delete(Guid id)
        {
            var subcategory = _subcategoryService.GetById(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var subcategory = _subcategoryService.GetById(id);
            if (subcategory != null)
            {
                _subcategoryService.DeleteById(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool SubcategoryExists(Guid id)
        {
            return _subcategoryService.GetById(id) != null;
        }
    }
}
