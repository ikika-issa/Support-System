using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public interface INoteService
    {
        public Note GetById(Guid id);
        public Note Insert(Note note);
        public Note Update(Note note);
        public Note DeleteById(Guid id);
    }
}
