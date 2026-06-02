using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interfaces
{
    public interface ITicketExportService
    {
        byte[] ExportToExcel(List<Ticket> tickets);

        byte[] ExportToPdf(List<Ticket> tickets);

        byte[] ExportToCsv(List<Ticket> tickets);

        byte[] ExportToDocx(List<Ticket> tickets);

        byte[] ExportToHtml(List<Ticket> tickets);

        byte[] ExportToXml(List<Ticket> tickets);
    }
}
