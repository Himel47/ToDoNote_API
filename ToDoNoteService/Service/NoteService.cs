using ToDoNoteData.Data;
using ToDoNoteData.Dto;
using ToDoNoteData.Entities;
using ToDoNoteService.Interface;

namespace ToDoNoteService.Service
{
    public class NoteService : INoteService
    {
        private readonly dbConnection connection;

        public NoteService(dbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<AddNote> AddNoteAsync(AddNote addNote)
        {
            if (addNote != null)
            {
                var note = new Note()
                {
                    Title = addNote.Title,
                    Descrition = addNote.Descrition,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                };
                if (addNote.AttachedPhoto != null)
                {
                    note.ImagePath = Path.Combine(@"C:\Users\BS358\Documents\ToDoNote_API\ToDoNoteData\Photos\NoteAttachment\", $"{addNote.Title}.jpg");
                    using Stream stream = new FileStream(note.ImagePath, FileMode.Create);
                    await addNote.AttachedPhoto.CopyToAsync(stream);
                }
                connection.Notes.Add(note);
                var SaveNote = Save();
                if (SaveNote)
                {
                    return addNote;
                }
            }
            return null;
        }
        public ICollection<Note> GetAllNoteAsync()
        {
            var AllNotes = connection.Notes.OrderBy(x => x.Id).ToList();
            foreach(var note in AllNotes)
            {
                note.CreatedBy = (int)note.Id;
            }
            return AllNotes;
        }
        public async Task<Note> GetNoteByIdAsync(int id)
        {
            var NoteById = connection.Notes.Where(x => x.Id == id).SingleOrDefault();
            NoteById.CreatedBy = id;
            return NoteById;
        }
        public async Task<Note> DeleteNoteAsync(int id)
        {
            var deletedNote = connection.Notes.Where(x => x.Id == id).FirstOrDefault();
            if (deletedNote != null)
            {
                deletedNote.IsActive = false;
                var SaveDelete = Save();
                if(SaveDelete) { return deletedNote; }
            }
            return null;
        }
        public async Task<AddNote> UpdateNoteAsync(AddNote note)
        {
            var NoteById = connection.Notes.Where(x => x.Id == note.Id).SingleOrDefault();
            if (NoteById != null)
            {
                NoteById.Title = note.Title;
                NoteById.Descrition = note.Descrition;
                NoteById.UpdatedBy = note.Id;
                NoteById.UpdatedDate = DateTime.Now;
                if (note.AttachedPhoto != null)
                {
                    NoteById.ImagePath = Path.Combine(@"C:\Users\BS358\Documents\ToDoNote_API\ToDoNoteData\Photos\NoteAttachment\", $"{note.Title}.jpg");
                    using Stream stream = new FileStream(NoteById.ImagePath, FileMode.Create);
                    await note.AttachedPhoto.CopyToAsync(stream);
                }
                connection.Notes.Update(NoteById);
                var SaveUpdate = Save();
                if (SaveUpdate)
                {
                    return note;
                }
            }
            return null;
        }
        public bool IfIdExist(int id)
        {
            return connection.Notes.Any(x => x.Id == id);
        }
        public bool Save() => connection.SaveChanges() > 0 ? true : false;
    }
}
