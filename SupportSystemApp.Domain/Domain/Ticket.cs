using SupportSystemApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class Ticket : BaseEntity
    {
        public string? TicketNumber { get; set; }
        public string? Header { get; set; }
        public string? Details { get; set; }
        public TicketStatus? Status { get; set; }
        public TicketPriority? Priority { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueBy { get; set; }
        public DateTime? ResolvedAt { get; set; }

        public string? RequesterId { get; set; }
        public virtual SupportSystemAppUser? OpenedBy { get; set; }

        public string? TechnitianId { get; set; }
        public virtual SupportSystemAppUser? AssignedTo { get; set; }
        public Guid? SiteId { get; set; }
        public virtual Site? Site { get; set; }
        public Guid? SupportGroupId { get; set; }
        public virtual SupportGroup? SupportGroup { get; set; }
        public virtual ICollection<TicketTask>? TicketTasks { get; set; }
        public virtual ICollection<Note>? Notes { get; set; }
        public virtual ICollection<Attachment>? Attachments { get; set; }

    }
}
