using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Turns.Citizen
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private BusinessLogicLayer.Application.ApplicationMethods _application;
        private BusinessLogicLayer.BLTurns.Citizen _blCitizen;
        public CitizenController(/*SignInManager*/)
        {
            _blCitizen = new BusinessLogicLayer.BLTurns.Citizen();
            _application = new BusinessLogicLayer.Application.ApplicationMethods();
        }

        [HttpGet]
        public IActionResult GetAllCitizens([FromQuery] PaginationDto pagination)
        {
            var citizens = _blCitizen.GetAllCitizens();

            if (citizens != null)
            {
                try
                {
                    var result = _application.GetPaginatedResult(citizens, pagination.PageNumber, pagination.PageSize);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("NotFound Any Citizens");
        }

        [HttpGet("{id}")]
        public List<EntityModel.Turns.Citizen>? GetCitizenById(string id)
        {
            return _blCitizen.GetCitizensById(id);
        }
    }
}
