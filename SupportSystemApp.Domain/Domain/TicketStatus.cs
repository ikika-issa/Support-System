using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public enum TicketStatus
    {
        Open,
        InProgress,
        PendingInvestigation,
        PendingPartner,
        PendingResponse,
        PendingReturn,
        PendingDelivery,
        PendingApproval,
        OnHold,
        Monitoring,
        Assigned,
        Cancelled,
        Closed,
        StartersLeavers
    }
}
