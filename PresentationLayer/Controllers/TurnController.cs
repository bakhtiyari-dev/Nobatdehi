using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TurnController : ControllerBase
    {
        [HttpGet] 
        public IActionResult GetAllOTurns()
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")] 
        public IActionResult GetTurnById(int id)
        {
            return Ok("GET ALL");
        }

        [HttpPost("{id}")] 
        public IActionResult CreateTurn(int id)
        {
            return Ok("GET ALL");
        }

        [HttpDelete("{id}")] 
        public IActionResult DeleteTurn(int id)
        {
            return Ok("Delete");
        }
    }


}
