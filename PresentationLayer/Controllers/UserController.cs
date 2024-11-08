using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet] 
        public IActionResult GetAllUsers()
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")] 
        public IActionResult GetUsersById(int id)
        {
            return Ok("GET ALL");
        }

        [HttpPost("{id}")] 
        public IActionResult CreateUsers(int id)
        {
            return Ok("GET ALL");
        }

        [HttpPut("{id}")] 
        public IActionResult UpdateUsers(int id)
        {
            return Ok("Update");
        }

        [HttpDelete("{id}")] 
        public IActionResult DeleteUsers(int id)
        {
            return Ok("Delete");
        }
    }
}
