using EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        public enum IdType
        {
            auto,
            Passport,
            UniqId,
            HouseholdId,
            ExclusiveId
        }

        [HttpGet] // GET: api/Citizen
        public IActionResult GetAllCitizens()
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")] // GET: api/Citizen/{id}
        public IActionResult GetCitizenById(int id = 0, IdType idType = IdType.auto)
        {
            return Ok("GET ALL");
        }
    }
}
