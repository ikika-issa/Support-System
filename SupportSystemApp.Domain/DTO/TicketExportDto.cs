using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.DTO
{
    public class TicketExportDto
    {
        public string? RequestID { get; set; }
        public string? Subject { get; set; }
        public string? Requester { get; set; }
        public string? Technician { get; set; }
        public DateTime? DueBy { get; set; }
        public string? Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Site? Site { get; set; }
        public TicketPriority? Priority { get; set; }
        public SupportGroup? SupportGroup { get; set; }
    }
}
