using EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet] // GET: api/Users
        public IActionResult GetAllUsers()
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")] // GET: api/Users/{id}
        public IActionResult GetUsersById(int id)
        {
            return Ok("GET ALL");
        }

        [HttpPost("{id}")] // POST: api/Users
        public IActionResult CreateUsers(int id)
        {
            return Ok("GET ALL");
        }

        [HttpPut("{id}")] // PUT: api/Users/{id}
        public IActionResult UpdateUsers(int id)
        {
            return Ok("Update");
        }

        [HttpDelete("{id}")] // DELETE: api/Users/{id}
        public IActionResult DeleteUsers(int id)
        {
            return Ok("Delete");
        }
    }
}
