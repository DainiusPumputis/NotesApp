using Persistence.Models;
using Persistence.Repositories;
using System;
namespace Domain.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository _notesRepository;

        public NotesService(INotesRepository notesRepository)
        {
            _notesRepository = notesRepository;
        }

        public void ClearAll()
        {
            _notesRepository.DeleteAll();
        }

        public void Create(Note note)
        {
            _notesRepository.Save(note);
        }

        public void DeleteById(int id)
        {
            _notesRepository.Delete(id);
        }

        public void Edit(int id, string title, string text)
        {
            _notesRepository.Edit(id, title, text);
        }

        public IEnumerable<Note> GetAll()
        {
            //var allNotes = _notesRepository.GetAll();
            //var validNotes = allNotes.Where(note => note.Text.Length >= 10);
            //return validNotes;

            return _notesRepository.GetAll();
        }
    }
}
