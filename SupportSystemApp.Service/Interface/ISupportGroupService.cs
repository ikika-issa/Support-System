using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface ISupportGroupService
    {
        List<SupportGroup> GetAll();
        SupportGroup GetById(Guid id);
        SupportGroup Insert(SupportGroup supportGroup);
        SupportGroup Update(SupportGroup supportGroup);
        SupportGroup Delete(Guid id);
    }
}
