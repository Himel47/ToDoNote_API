using ToDoNoteAPI.Models;
using ToDoNoteAPI.Models.Dto;

namespace ToDoNoteAPI.Interfaces
{
    public interface INoteRepository
    {
        ICollection<Note> GetAllNotes();
        Note GetParticularById(int id);
        bool ifIdExist(int id);
        bool AddNewNote(NoteAttachment note);
        //bool UpdateNote(NoteAttachment note);
        bool DeleteNote(int id);
        bool Save();
    }
}
