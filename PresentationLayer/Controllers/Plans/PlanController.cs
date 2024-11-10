using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PresentationLayer.Controllers.Plans
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

        //Plan

        [HttpGet(Name = "get all plans")]

        public IActionResult GetAllPlans()
        {
            return Ok("GET ALL");
        }

        [HttpGet("{id}")]
        public IActionResult GetPlanById(int id)
        {
            return Ok("GET");
        }

        [HttpPost("{id}")]
        public IActionResult CreatePlan(string name, DateOnly firstDate, DateOnly lastDate, CitizenIdType citizenIdType, bool generalCreationFlag, [SwaggerParameter(Description = "set minute")] int turnTimeGap)
        {
            return Ok("Create");
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePlan(int id, string name, DateOnly firstDate, DateOnly lastDate, CitizenIdType citizenIdType, bool generalCreationFlag, [SwaggerParameter(Description = "set minute")] int turnTimeGap)
        {
            return Ok("Update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlan(int id)
        {
            return Ok("Delete");
        }

        //Capacity

        [HttpPut("capacity")]
        public IActionResult setcapacity(int officeId, int planId, string operationType, int newCapacity)
        {
            return Ok("Update");
        }

        //Dependencies

        [HttpGet("dependency")]
        public IActionResult GetAllDependencies()
        {
            return Ok("GET ALL");
        }

        [HttpPost("dependency")]
        public IActionResult CreateDependency(int dependentId, int independentId)
        {
            return Ok("Create");
        }

        [HttpPut("dependency")]
        public IActionResult UpdateDependency(int id, int dependentId, int independentId)
        {
            return Ok("Update");
        }

        [HttpDelete("dependency")]
        public IActionResult DeleteDependency(int id)
        {
            return Ok("Delete");
        }

        //Office Plan Option

        [HttpPost("officeOption")]
        public IActionResult CreateOfficePlanOption(int officeId, int PlanId, DateOnly firstDate, DateOnly lastDate, int capacity)
        {
            return Ok("Create");
        }

        [HttpPut("officeOption")]
        public IActionResult UpdateOfficePlanOption(int officeId, int PlanId, DateOnly firstDate, DateOnly lastDate, int capacity)
        {
            return Ok("Update");
        }

        [HttpDelete("officeOption")]
        public IActionResult DeleteOfficePlanOption(int officeId, int PlanId)
        {
            return Ok("Delete");
        }

        //Work Plan

        [HttpGet("workPlan")]
        public IActionResult GetWorkPlan(int officeId, int PlanId)
        {
            return Ok("Get Office Work Plan");
        }

        [HttpPost("workPlan")]
        public IActionResult CreateWorkPlan(int officeId, int PlanId,
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

        [HttpPut("workPlan")]
        public IActionResult UpdateWorkPlan(int officeId, int PlanId,
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

            return Ok("Update");
        }

        [HttpDelete("workPlan")]
        public IActionResult DeleteWorkPlan(int officeId, int PlanId)
        {
            return Ok("Delete");
        }
    }
}
