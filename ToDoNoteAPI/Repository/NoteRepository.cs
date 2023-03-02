using ToDoNoteAPI.Data;
using ToDoNoteAPI.Interfaces;
using ToDoNoteAPI.Models;
using ToDoNoteAPI.Models.Dto;

namespace ToDoNoteAPI.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly dbConnection connection;
        private readonly IWebHostEnvironment environment;

        public NoteRepository(dbConnection connection, IWebHostEnvironment environment)
        {
            this.connection = connection;
            this.environment = environment;
        }

        public bool AddNewNote(NoteAttachment note)
        {
            var newNote = new Note()
            {
                Title = note.Title,
                noteDescrition = note.noteDescrition,
                isActive = note.isActive,
                CreatedBy = note.CreatedBy,
                imagePath = Path.Combine(@"C:\Users\BS358\Documents\ToDoNote_API\ToDoNoteAPI\wwwroot\Images", $"{note.Title}.jpg"),
                CreatedDate = note.CreatedDate,
                UpdatedDate = note.UpdatedDate,
            };
            using(Stream stream =new FileStream(newNote.imagePath, FileMode.Create))
            {
                note.attachedPhoto.CopyTo(stream);
            }
            connection.NoteDetails.Add(newNote);
            return Save();
        }

        /*public bool UpdateNote(Note note)
        {
            connection.NoteDetails.Update(note);
            return Save();
        }*/

        public ICollection<Note> GetAllNotes()
        {
            return connection.NoteDetails.OrderBy(x => x.Id).ToList();
        }

        public Note GetParticularById(int id)
        {
            return connection.NoteDetails.Where(x => x.Id == id).SingleOrDefault();
        }

        public bool ifIdExist(int id)
        {
            return connection.NoteDetails.Any(x => x.Id == id);
        }

        public bool Save()
        {
            var saved = connection.SaveChanges();
            return saved>0 ? true : false;
        }

        public bool DeleteNote(int id)
        {
            var deletedNote = connection.NoteDetails.Where(x=>x.Id == id).FirstOrDefault();
            deletedNote.isActive=false;
            return Save();
        }
    }
}
