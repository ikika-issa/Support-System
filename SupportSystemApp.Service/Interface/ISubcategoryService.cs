using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface ISubcategoryService
    {
        public List<Subcategory> GetAllByCategoryId(Guid categoryId);
        public Subcategory GetById(Guid id);
        public Subcategory GetByCategory(Guid categoryId);
        public Subcategory Insert(Subcategory subcategory);
        public Subcategory Update(Subcategory subcategory);
        public Subcategory DeleteById(Guid id);
    }
}
