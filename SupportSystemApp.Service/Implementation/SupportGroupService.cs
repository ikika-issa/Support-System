using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class SupportGroupService : ISupportGroupService
    {
        private readonly IRepository<SupportGroup> _supportGroupRepository;

        public SupportGroupService(IRepository<SupportGroup> supportGroupRepository)
        {
            _supportGroupRepository = supportGroupRepository;
        }


        public SupportGroup Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<SupportGroup> GetAll()
        {
            return _supportGroupRepository.GetAll(selector: x => x).ToList();
        }

        public SupportGroup GetById(Guid id)
        {
            return _supportGroupRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public SupportGroup Insert(SupportGroup supportGroup)
        {
            supportGroup.Id = Guid.NewGuid();
            return _supportGroupRepository.Insert(supportGroup);
        }

        public SupportGroup Update(SupportGroup supportGroup)
        {
            return _supportGroupRepository.Update(supportGroup);
        }
    }
}
