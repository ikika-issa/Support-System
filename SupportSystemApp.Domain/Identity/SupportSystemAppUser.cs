using Microsoft.AspNetCore.Identity;
using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Identity
{
    public class SupportSystemAppUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public virtual ICollection<Ticket>? OpenedTickets { get; set; }
         public virtual ICollection<Ticket>? AssignedTickets { get; set; }
    }
}
