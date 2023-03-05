using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoNoteData.Data;

namespace ToDoNoteAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly dbConnection connection;

        public UserController(dbConnection connection)
        {
            this.connection = connection;
        }
    }
}
