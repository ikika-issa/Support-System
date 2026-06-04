using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class CategoryItemService : ICategoryItemService
    {
        public CategoryItem DeleteById(Guid ID)
        {
            throw new NotImplementedException();
        }

        public CategoryItem GetByID(Guid ID)
        {
            throw new NotImplementedException();
        }

        public List<CategoryItem> GetCategoryItemsBySubcategoryID(Guid SubcategoryID)
        {
            throw new NotImplementedException();
        }

        public CategoryItem Insert(CategoryItem categoryItem)
        {
            throw new NotImplementedException();
        }

        public CategoryItem Update(CategoryItem categoryItem)
        {
            throw new NotImplementedException();
        }
    }
}
