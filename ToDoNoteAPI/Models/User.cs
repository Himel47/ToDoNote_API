using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ToDoNoteAPI.Models
{
    public class User
    {
        [Key]
        public string? Name { get; set;}

        [Required(ErrorMessage ="Enter Valid Mail Address!")]
        public string? Email { get; set; }
        public bool isActive { get; set; }
        [Required(ErrorMessage ="Upload an Image!")]
        public string? ProfilePicture { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
