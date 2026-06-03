using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain_Models
{
    public class NoteInTicket : BaseEntity
    {
        public Guid TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public Guid NoteId { get; set; }
        public virtual Note? Note { get; set; }
    }
}