using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class SubcategoryService : ISubcategoryService
    {
        private readonly IRepository<Subcategory> _subcategoryRepository;

        public SubcategoryService(IRepository<Subcategory> subcategoryRepository)
        {
            _subcategoryRepository = subcategoryRepository;
        }

        public Subcategory DeleteById(Guid id)
        {
            var subcategory = _subcategoryRepository.Get(selector: x => x, predicate: x => x.Id == id);

            if (subcategory == null)
            {
                throw new Exception($"Subcategory with id {id} not found.");
            }

            _subcategoryRepository.Delete(subcategory);
            return subcategory;
        }

        public List<Subcategory> GetAllByCategoryId(Guid categoryId)
        {
            return _subcategoryRepository.GetAll(selector: x => x, predicate: x => x.CategoryId == categoryId).ToList();
        }

        public Subcategory GetById(Guid id)
        {
            return _subcategoryRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public Subcategory Insert(Subcategory subcategory)
        {
            subcategory.Id = Guid.NewGuid();
            return _subcategoryRepository.Insert(subcategory);
        }

        public Subcategory Update(Subcategory subcategory)
        {
            return _subcategoryRepository.Update(subcategory);
        }
    }
}
