using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public class TaskReminder : BaseEntity
    {
        public int NotifyBeforeMinutes { get; set; }
        public string? Unit { get; set; } //Minutes, Hours, Days
        public bool IsEnabled { get; set; }
    }
}
