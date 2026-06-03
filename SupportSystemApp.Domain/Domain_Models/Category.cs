using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<Subcategory>? Subcategories { get; set; }
    }
}
