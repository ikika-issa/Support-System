using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public interface ICategoryItemService
    {
        public List<CategoryItem> GetCategoryItemsBySubcategoryID(Guid SubcategoryID);
        public CategoryItem GetByID(Guid ID);
        public CategoryItem Update(CategoryItem categoryItem);
        public CategoryItem Insert(CategoryItem categoryItem);
        public CategoryItem DeleteById(Guid ID);

    }
}
