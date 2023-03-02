using System.ComponentModel.DataAnnotations;

namespace ToDoNoteAPI.Models.Dto
{
    public class NoteAttachment
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [Required(ErrorMessage = "Write Something on the note body!")]
        public string? noteDescrition { get; set; }
        public bool isActive { get; set; }
        public string? CreatedBy { get; set; }
        public IFormFile? attachedPhoto { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
