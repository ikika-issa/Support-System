using SupportSystemApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class SupportGroup : BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<SupportSystemAppUser>? Users { get; set; }
    }
}
