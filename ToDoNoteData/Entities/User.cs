using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoNoteData.Entities
{
    public class User:Base
    {
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter Valid Mail Address!")]
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "Upload an Image!")]
        public string? ProfilePicture { get; set; }
    }
}
