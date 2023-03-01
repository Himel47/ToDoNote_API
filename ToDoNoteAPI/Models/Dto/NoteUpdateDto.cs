using System.ComponentModel.DataAnnotations;

namespace ToDoNoteAPI.Models.Dto
{
    public class NoteUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string noteDescrition { get; set; }
        public bool isActive { get; set; }
        public string? attachedPhoto { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
