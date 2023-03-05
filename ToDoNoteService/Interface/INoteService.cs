using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoNoteData.Dto;
using ToDoNoteData.Entities;

namespace ToDoNoteService.Interface
{
    public interface INoteService
    {
        Task<AddNote> AddNoteAsync(AddNote addNote);
        Task<AddNote> UpdateNoteAsync(AddNote note);
        ICollection<Note> GetAllNoteAsync();
        Task<Note> GetNoteByIdAsync(int id);
        Task<Note> DeleteNoteAsync(int id);
        bool ifIdExist(int id);
        bool Save();
    }
}
