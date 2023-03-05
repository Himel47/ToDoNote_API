using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoNoteData.Entities
{
    public class Note:Base
    {
        public string? Title { get; set; }

        [Required(ErrorMessage = "Write Something on the note body!")]
        public string? Descrition { get; set; }
        public bool IsActive { get; set; }
        public string? ImagePath { get; set; }

    }
}
