using SupportSystemApp.Domain.Domain;
using SupportSystemApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportSystemApp.Service.Implementation
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public Note DeleteById(Guid id)
        {
            var note = _noteRepository.Get(selector: x => x, predicate: x => x.Id == id);

            if (note == null)
            {
                throw new Exception($"Note with id {id} not found.");
            }

            _noteRepository.Delete(note);
            return note;    
        }

        public Note GetById(Guid id)
        {
            return _noteRepository.Get(selector: x => x, predicate: x => x.Id == id)!;
        }

        public Note Insert(Note note)
        {
            note.Id = Guid.NewGuid();
            return _noteRepository.Insert(note);
        }

        public Note Update(Note note)
        {
            return _noteRepository.Update(note);
        }
    }
}
