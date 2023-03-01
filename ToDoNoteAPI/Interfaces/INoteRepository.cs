using ToDoNoteAPI.Models;

namespace ToDoNoteAPI.Interfaces
{
    public interface INoteRepository
    {
        ICollection<Note> GetAllNotes();
        Note GetParticularById(int id);
        bool ifIdExist(int id);
        bool AddNewNote(Note note);
        bool UpdateNote(Note note);
        bool DeleteNote(int id);
        bool Save();
    }
}
