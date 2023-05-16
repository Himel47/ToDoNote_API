using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoNoteData.Dto
{
    public class AddNote
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [Required(ErrorMessage = "Write Something on the note body!")]
        public string? Descrition { get; set; }
        public IFormFile? AttachedPhoto { get; set; }

    }
}
