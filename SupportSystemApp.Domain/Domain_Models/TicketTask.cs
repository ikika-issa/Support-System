using SupportSystemApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class TicketTask : BaseEntity
    {
        public string? Title { get; set; }
        public TicketStatus? Status { get; set; }
        public string? Description { get; set; }
        public Guid? SupportGroupId { get; set; }
        public virtual SupportGroup? SupportGroup { get; set; }
        public TicketPriority? Priority { get; set; }
        public DateTime? ScheduleStart { get; set; }
        public DateTime? ScheduleEnd { get; set; }
        public string? SupportSystemAppUserId { get; set; } //ASSIGNED TO
        public virtual SupportSystemAppUser? SupportSystemAppUser { get; set; }
        public TaskType? TaskType { get; set; }
        public DateTime? ActualStart { get; set; }
        public DateTime? ActualEnd { get; set; }
        public int? Progress; //0-100
        public TaskReminder? TaskReminder { get; set; }
        public virtual ICollection<Attachment>? Attachments { get; set; }
    }
}
