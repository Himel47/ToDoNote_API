using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoNoteData.Dto
{
    public class NewUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter your valid e-mail address!")]
        public string? Email { get; set; }
        public IFormFile? ProfilePhoto { get; set; }
    }
}
