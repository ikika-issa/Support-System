using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class CategoryItem : BaseEntity
    {
        public string? Name { get; set; }
        public Guid SubcategoryId { get; set; }
        public virtual Subcategory? Subcategory { get; set; }
    }
}
