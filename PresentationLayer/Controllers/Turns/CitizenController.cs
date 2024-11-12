using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers.Turns.Citizen
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

        [HttpGet]
        public IActionResult GetAllCitizens()
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")]
        public IActionResult GetCitizenById(int id = 0, [FromQuery] IdType idType = IdType.auto)
        {
            return Ok("GET ALL");
        }
    }
}
