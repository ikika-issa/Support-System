using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class Subcategory : BaseEntity
    {
        public string? Name { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<CategoryItem>? CategoryItems { get; set; }
    }
}
