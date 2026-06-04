using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface ITicketTaskService
    {
        List<TicketTask> GetAllTasksByTicketId(Guid ticketId);
        TicketTask GetTaskById(Guid taskId);
        TicketTask GetById(Guid taskId);
        TicketTask Insert(TicketTask task, Guid ticketId);
        TicketTask Update(TicketTask task);
        TicketTask Delete(Guid taskId, Guid ticketId);
    }
}
