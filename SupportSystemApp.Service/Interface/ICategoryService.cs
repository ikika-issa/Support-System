using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public interface ICategoryService
    {
        public List<Category> GetAll();
        public Category GetById(Guid id);
        public Category Insert(Category category);
        public Category Update(Category category);
        public Category DeleteById(Guid id);
    }
}
