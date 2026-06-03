using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class TicketTaskService : ITicketTaskService
    {
        private readonly IRepository<TicketTask> _ticketTaskRepository;
        private readonly IRepository<TaskInTicket> _taskInTicketRepository;

        public TicketTaskService(IRepository<TicketTask> ticketTaskRepository, IRepository<TaskInTicket> taskInTicketRepository)
        {
            _ticketTaskRepository = ticketTaskRepository;
            _taskInTicketRepository = taskInTicketRepository;
        }

        public TicketTask Delete(Guid taskId)
        {
            var task = GetTaskById(taskId);

            if (task == null)
            {
                throw new Exception("Task not found.");
            }

            _ticketTaskRepository.Delete(task);

            return task;
        }

        public List<TicketTask> GetAllTasksByTicketId(Guid ticketId)
        {
            return _taskInTicketRepository.GetAll(selector: x => x.Task, predicate: x => x.TicketId == ticketId).ToList();
        }

        public TicketTask GetTaskById(Guid taskId)
        {
            return _ticketTaskRepository.Get(selector: x => x, predicate: x => x.Id == taskId)!;
        }

        public TicketTask Insert(TicketTask task)
        {
            task.Id = Guid.NewGuid();
            return _ticketTaskRepository.Insert(task);
        }

        public TicketTask Update(TicketTask task)
        {
            return _ticketTaskRepository.Update(task);
        }
    }
}
