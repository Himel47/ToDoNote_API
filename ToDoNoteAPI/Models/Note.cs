﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoNoteAPI.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }

        [Required(ErrorMessage ="Write Something on the note body!")]
        public string? noteDescrition { get; set; }
        public bool isActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? imagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
