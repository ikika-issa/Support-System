using SupportSystemApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class TicketShare : BaseEntity
    {
        public Guid TicketId { get; set; }
        public string? UserId { get; set; }
       // public SupportSystemAppUser SupportSystemAppUser { get; set; }
        public Guid? SupportGroupId { get; set; }
        public virtual SupportGroup? SupportGroup { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public virtual SupportSystemAppUser? User { get; set; }
    }
}
