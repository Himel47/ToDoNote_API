using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ToDoNoteData.Dto;
using ToDoNoteService.Interface;

namespace ToDoNoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var notes = noteService.GetAllNoteAsync().ToList();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(notes);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetNotebyId(int Id)
        {
            if (!noteService.ifIdExist(Id))
            {
                return NotFound();
            }
            var noteById = await noteService.GetNoteByIdAsync(Id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(noteById);
        }

        [HttpPost]
        public async Task<IActionResult> AddNote([FromForm] AddNote note)
        {
            var response = await noteService.AddNoteAsync(note);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNote([FromForm] AddNote note)
        {
            var updateNote =await noteService.UpdateNoteAsync(note);
            return StatusCode(StatusCodes.Status200OK,updateNote);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteNoteAsync(int Id)
        {
            if (!noteService.ifIdExist(Id))
            {
                return NotFound();
            }
            var noteById = noteService.DeleteNoteAsync(Id);
            return Ok("Note Moved to Trash!");
        }
    }
}
