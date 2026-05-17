using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;

        public TicketService(IRepository<Ticket> ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Ticket DeleteById(Guid id)
        {
            var ticket = _ticketRepository.Get(selector: x => x, predicate: x => x.Id == id);

            if (ticket == null)
            {
                throw new Exception($"Ticket with id {id} not found.");
            }

            _ticketRepository.Delete(ticket);
            return ticket;  
        }

        public List<Ticket> GetAll()
        {
            return _ticketRepository.GetAll(selector: x => x).ToList();
        }

        public Ticket GetById(Guid id)
        {
            return _ticketRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public Ticket Insert(Ticket ticket)
        {
            ticket.Id = Guid.NewGuid();
            ticket.CreatedAt = DateTime.UtcNow; //CHECK LATER
            return _ticketRepository.Insert(ticket);
        }

        public Ticket Update(Ticket ticket)
        {
            return _ticketRepository.Update(ticket);
        }
    }
}
