using ToDoNoteAPI.Data;
using ToDoNoteAPI.Interfaces;
using ToDoNoteAPI.Models;

namespace ToDoNoteAPI.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly dbConnection connection;

        public NoteRepository(dbConnection connection)
        {
            this.connection = connection;
        }

        public bool AddNewNote(Note note)
        {
            note.CreatedDate = DateTime.Now;
            note.UpdatesDate = DateTime.Now;

            connection.Notes.Add(note);
            return Save();
        }

        public bool UpdateNote(Note note)
        {
            connection.Notes.Update(note);
            return Save();
        }

        public ICollection<Note> GetAllNotes()
        {
            return connection.Notes.OrderBy(x => x.Id).ToList();
        }

        public Note GetParticularById(int id)
        {
            return connection.Notes.Where(x => x.Id == id).SingleOrDefault();
        }

        public bool ifIdExist(int id)
        {
            return connection.Notes.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = connection.SaveChanges();
            return saved>0 ? true : false;
        }

        public bool DeleteNote(int id)
        {
            var deletedNote = connection.Notes.Where(x=>x.Id == id).FirstOrDefault();
            deletedNote.isActive=false;
            return Save();
        }
    }
}
