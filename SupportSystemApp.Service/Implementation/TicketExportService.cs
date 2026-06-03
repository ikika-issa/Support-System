using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class TicketExportService : ITicketExportService
    {
        public byte[] ExportToCsv(List<Ticket> tickets)
        {
            throw new NotImplementedException();
        }

        public byte[] ExportToDocx(List<Ticket> tickets)
        {
            throw new NotImplementedException();
        }

        public byte[] ExportToExcel(List<Ticket> tickets)
        {
            throw new NotImplementedException();
        }

        public byte[] ExportToHtml(List<Ticket> tickets)
        {
            throw new NotImplementedException();
        }

        public byte[] ExportToPdf(List<Ticket> tickets)
        {
            throw new NotImplementedException();
        }

        public byte[] ExportToXml(List<Ticket> tickets)
        {
            throw new NotImplementedException();
        }
    }
}
