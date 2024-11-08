using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class OfficeController : ControllerBase
    {
        public enum Cities
        {
            Azerbaijan,
            Fars,
            Isfahan,
            Qazvin,
            Tehran,
            Yazd,
            Zanjan
        }

        [HttpGet] 
        public IActionResult GetAllOffices()
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")] 
        public IActionResult GetOfficeById(int id)
        {
            return Ok("GET ALL");
        }

        [HttpPost] 
        public IActionResult CreateOffice(Cities city, string phoneNumber)
        {
            return Ok("Create");
        }


        [HttpPut("{id}")] 
        public IActionResult UpdateOffice(int id, Cities city, string phoneNumber)
        {
            return Ok("Update");
        }

        [HttpDelete("{id}")] 
        public IActionResult DeleteOffice(int id)
        {
            return Ok("Delete");
        }
    }
}
