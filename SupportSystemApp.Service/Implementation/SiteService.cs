using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class SiteService : ISiteService
    {
        private readonly IRepository<Site> _siteRepository;

        public SiteService(IRepository<Site> siteRepository)
        {
            _siteRepository = siteRepository;
        }

        public Site DeleteById(Guid id)
        {
            var site = _siteRepository.Get(selector: x => x, predicate: x => x.Id == id);

            if (site == null)
            {
                throw new Exception("Site not found.");
            }

            _siteRepository.Delete(site);

            return site;
        }

        public List<Site> GetAll()
        {
            return _siteRepository.GetAll(selector: x => x).ToList();
        }

        public Site GetById(Guid id)
        {
            return _siteRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public Site Insert(Site site)
        {
            site.Id = Guid.NewGuid();
            return _siteRepository.Insert(site);
        }

        public Site Update(Site site)
        {
            return _siteRepository.Update(site);
        }
    }
}
