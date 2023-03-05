using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoNoteData.Dto;
using ToDoNoteService.Interface;

namespace ToDoNoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = userService.GetAllUsersAsync().ToList();
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserById(int id)
        {
            if (userService.ifIdExist(id))
            {
                return NotFound();
            }
            var UserById = await userService.GetUserByIdAsync(id);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(UserById);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser([FromForm] NewUser user)
        {
            var response = await userService.RegisterUserAsync(user);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromForm] NewUser user)
        {
            var UpdateUser = await userService.UpdateUserAsync(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return StatusCode(StatusCodes.Status200OK, UpdateUser);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if(!userService.ifIdExist(id))
            {
                return NotFound();
            }
            var DeleteById = userService.DeleteUserAsync(id);
            return Ok($"User with id {DeleteById} Moved To Trash!");
        }
    }
}
