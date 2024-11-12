using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PresentationLayer.Controllers.Offices.OfficeWorkPlan
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeWorkPlanController : ControllerBase
    {
        public OfficeWorkPlanController()
        {

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
