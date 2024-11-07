using EntityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        public enum CitizenIdType
        {
            Passport,
            UniqId,
            HouseholdId,
            ExclusiveId
        }

        
        [HttpGet(Name = "get all plans")] 

        public IActionResult GetAllPlans()
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")] 
        public IActionResult GetPlanById(int id)
        {
            return Ok("GET ALL");
        }

        [HttpPost("{id}")] 
        public IActionResult CreatePlan(string name, DateOnly firstDate, DateOnly lastDate, CitizenIdType citizenIdType, bool generalCreationFlag, int turnTimeGap)
        {
            return Ok("GET ALL");
        }

        [HttpPut("{id}")] 
        public IActionResult UpdatePlan(int id, string name, DateOnly firstDate, DateOnly lastDate, CitizenIdType citizenIdType, bool generalCreationFlag, int turnTimeGap)
        {
            return Ok("Update");
        }

        [HttpDelete("{id}")] 
        public IActionResult DeletePlan(int id)
        {
            return Ok("Delete");
        }

        //PlanOption Actions

        [HttpPost("office-option/{id}")] 
        public IActionResult CreateOfficePlanOption(int id)
        {
            return Ok("Update");
        }

        [HttpPut("office-option/{id}")] 
        public IActionResult UpdateOfficePlanOption(int id)
        {
            return Ok("Update");
        }

        [HttpDelete("office-option")] 
        public IActionResult DeleteOfficePlanOption(int id)
        {
            return Ok("Delete");
        }

        [HttpGet("workplan")]
        public IActionResult WeeklyHours(
            [SwaggerParameter(Description = "First hour for Saturday")] string saturdayFirstHour,
            [SwaggerParameter(Description = "Last hour for Saturday")] string saturdayLastHour,

            [SwaggerParameter(Description = "First hour for Sunday")] string sundayFirstHour,
            [SwaggerParameter(Description = "Last hour for Sunday")] string sundayLastHour,

            [SwaggerParameter(Description = "First hour for Monday")] string mondayFirstHour,
            [SwaggerParameter(Description = "Last hour for Monday")] string mondayLastHour,

            [SwaggerParameter(Description = "First hour for Tuesday")] string tuesdayFirstHour,
            [SwaggerParameter(Description = "Last hour for Tuesday")] string tuesdayLastHour,

            [SwaggerParameter(Description = "First hour for Wednesday")] string wednesdayFirstHour,
            [SwaggerParameter(Description = "Last hour for Wednesday")] string wednesdayLastHour,

            [SwaggerParameter(Description = "First hour for Thursday")] string thursdayFirstHour,
            [SwaggerParameter(Description = "Last hour for Thursday")] string thursdayLastHour,

            [SwaggerParameter(Description = "First hour for Friday")] string fridayFirstHour,
            [SwaggerParameter(Description = "Last hour for Friday")] string fridayLastHour)
        {

            return Ok();
        }
    }
}
