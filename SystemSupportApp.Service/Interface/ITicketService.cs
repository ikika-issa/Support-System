using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public interface ITicketService
    {
        public List<Ticket> GetAll();
        public Ticket GetById(Guid id);
        public Ticket Insert(Ticket ticket);
        public Ticket Update(Ticket ticket);
        public Ticket DeleteById(Guid id);

    }
}
