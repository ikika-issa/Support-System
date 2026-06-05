using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class Category : BaseEntity
    {
        [Required]
        public string? Name { get; set; }
        public virtual ICollection<Subcategory>? Subcategories { get; set; }
    }
}
