using SupportSystemApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class Note : BaseEntity
    {
        public string? OpenedByUserId { get; set; }
        public virtual SupportSystemAppUser? OpenedByUser { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Attachment>? Attachments { get; set; }
    }
}
