using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class Site : BaseEntity
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
    }
}
