using SupportSystemApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class Attachment : BaseEntity
    {
        public string? FileName { get; set; }
        public string? StoredFileName { get; set; }
        public string? FilePath { get; set; }
        public long FileSize { get; set; }
        public string? ContentType { get; set; }
        public DateTime UploadedAt { get; set; }
        public string? SupportSystemAppUserId { get; set; }
        public virtual SupportSystemAppUser? UploadedByUser { get; set; }

        public Guid? TicketId { get; set; }
        public virtual Ticket? Ticket { get; set; }
        public Guid? TicketTaskId { get; set; }
        public virtual TicketTask? TicketTask { get; set; }
        public Guid? NoteId { get; set; }
        public virtual Note? Note { get; set; }
    }
}
