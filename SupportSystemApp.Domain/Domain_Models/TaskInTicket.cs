using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class TaskInTicket : BaseEntity
    {
        public Guid TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public Guid TaskId { get; set; }
        public TicketTask? Task { get; set; }
    }
}
