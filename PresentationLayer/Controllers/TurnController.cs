using EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class TurnController : ControllerBase
    {
        [HttpGet] // GET: api/Turn
        public IActionResult GetAllOTurns()
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")] // GET: api/Turn/{id}
        public IActionResult GetTurnById(int id)
        {
            return Ok("GET ALL");
        }

        [HttpPost("{id}")] // POST: api/Turn
        public IActionResult CreateTurn(int id)
        {
            return Ok("GET ALL");
        }

        [HttpDelete("{id}")] // DELETE: api/Turn/{id}
        public IActionResult DeleteTurn(int id)
        {
            return Ok("Delete");
        }
    }


}
