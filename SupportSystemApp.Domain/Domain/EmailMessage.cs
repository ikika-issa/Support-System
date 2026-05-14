using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class EmailMessage : BaseEntity
    {
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public DateTime ReceivedAt { get; set; }
        public bool Processed { get; set; }
        public Guid? TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
    }
}
