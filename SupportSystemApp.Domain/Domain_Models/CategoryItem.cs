using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class CategoryItem : BaseEntity
    {
        [Required]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please choose a subcategory.")]
        public Guid SubcategoryId { get; set; }
        public virtual Subcategory? Subcategory { get; set; }
    }
}
