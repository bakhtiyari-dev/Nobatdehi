using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using EntityModel;

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

        [HttpGet] // GET: api/office
        public IActionResult GetAllOffices() 
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")] // GET: api/office/{id}
        public IActionResult GetOfficeById(int id) 
        {
            return Ok("GET ALL");
        }

        [HttpPost] // POST: api/office
        public IActionResult CreateOffice(Office office) 
        {
            return Ok("GET ALL");
        }

        [HttpPut("{id}")] // PUT: api/office/{id}
        public IActionResult UpdateOffice(int id, Office office) 
        { 
            return Ok("Update");
        }

        [HttpDelete("{id}")] // DELETE: api/office/{id}
        public IActionResult DeleteOffice(int id) 
        {
            return Ok("Delete");
        }
    }
}
