using SupportSystemApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Interface
{
    public interface ISiteService
    {
        List<Site> GetAll();
        Site GetById(Guid id);
        Site Insert(Site site);
        Site Update(Site site);
        Site DeleteById(Guid id);
    }
}
