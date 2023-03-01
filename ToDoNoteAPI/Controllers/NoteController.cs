using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoNoteAPI.Interfaces;
using ToDoNoteAPI.Models;

namespace ToDoNoteAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteRepository noteRepository;

        public NoteController(INoteRepository noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var notes = noteRepository.GetAllNotes().ToList();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(notes);
        }

        [HttpGet("Id")]
        public IActionResult GetNotebyId(int Id)
        {
            if(!noteRepository.ifIdExist(Id))
            {
                return NotFound();
            }
            var noteById = noteRepository.GetParticularById(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(noteById);
        }

        [HttpPost]
        public IActionResult AddNote(Note note)
        {
            if(note == null)
            {
                return BadRequest(ModelState);
            }
            var newNote = noteRepository.AddNewNote(note);
            if (!newNote)
            {
                ModelState.AddModelError("","Something went Wrong!");
                return StatusCode(500,ModelState);
            }
            return Ok("Successfully Created New Note.");
        }

        [HttpPut]
        public IActionResult UpdateNote(Note note)
        {
            var updateNote = noteRepository.UpdateNote(note);
            if (!updateNote)
            {
                ModelState.AddModelError("", "Something went Wrong!");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully Updated Note.");
        }

        [HttpDelete("id")]
        public IActionResult DeleteNote(int Id)
        {
            if (!noteRepository.ifIdExist(Id))
            {
                return NotFound();
            }
            var noteById = noteRepository.DeleteNote(Id);
            return Ok("Note Moved to Trash!");
        }
    }
}
