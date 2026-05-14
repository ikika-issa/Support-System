using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Domain.Domain
{
    public enum TicketViewType
    {
        MyPendingRequests,
        MyOpenRequests,
        AllMyGroups,
        AllRequests,
        PendingRequests,
        RequestsDueToday,
        OverdueRequests,
        OpenRequests,
        RequestsOnHold,
        UnassignedRequests,
        MyOpenOrUnassigned,
        MyCompleted,
        MyRequestsDueToday,
        MyOverdueRequests,
        MyRequestsOnHold,
        AllMyRequests,
        UpdatedByMe,
        RequestsPendingApproval,
        CompletedRequests
    }
}
