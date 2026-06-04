using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class TicketTaskService : ITicketTaskService
    {
        private readonly IRepository<TicketTask> _ticketTaskRepository;
        private readonly IRepository<TaskInTicket> _taskInTicketRepository;
        private readonly ITicketService _ticketService;

        public TicketTaskService(IRepository<TicketTask> ticketTaskRepository, IRepository<TaskInTicket> taskInTicketRepository, 
            ITicketService ticketService)
        {
            _ticketTaskRepository = ticketTaskRepository;
            _taskInTicketRepository = taskInTicketRepository;
            _ticketService = ticketService;
        }

        public TicketTask Delete(Guid taskId, Guid TicketId)
        {
            var task = GetTaskById(taskId);
            var ticket = _ticketService.GetById(TicketId);

            if (task == null)
            {
                throw new Exception("Task not found.");
            }

            if (ticket == null)
            {
                throw new Exception("Ticket not found.");
            }

            var taskInTickets = _taskInTicketRepository.Get(selector: x => x, predicate: x => x.TaskId == taskId && x.TicketId == TicketId);

            _taskInTicketRepository.Delete(taskInTickets!);
            _ticketTaskRepository.Delete(task);

            return task;
        }


        public TicketTask GetById(Guid taskId)
        {
            return _ticketTaskRepository.Get(selector: x => x, predicate: x => x.Id == taskId)!;
        }

        public List<TicketTask> GetAllTasksByTicketId(Guid ticketId)
        {
            return _taskInTicketRepository.GetAll(selector: x => x.Task, predicate: x => x.TicketId == ticketId).ToList();
        }

        public TicketTask GetTaskById(Guid taskId)
        {
            return _ticketTaskRepository.Get(selector: x => x, predicate: x => x.Id == taskId)!;
        }

        public TicketTask Insert(TicketTask task, Guid ticketId)
        {
            task.Id = Guid.NewGuid();

            var taskInTicket = new TaskInTicket
            {
                Id = Guid.NewGuid(),
                TicketId = ticketId,
                Ticket = _ticketService.GetById(ticketId),
                TaskId = task.Id,
                Task = task
            };

            _taskInTicketRepository.Insert(taskInTicket);

            return _ticketTaskRepository.Insert(task);
        }

        public TicketTask Update(TicketTask task)
        {
            return _ticketTaskRepository.Update(task);
        }
    }
}
