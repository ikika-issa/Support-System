using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain_Models
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
