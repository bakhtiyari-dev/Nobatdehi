using EntityModel.Plans;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;
using Swashbuckle.AspNetCore.Annotations;

namespace PresentationLayer.Controllers.Plans
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private BusinessLogicLayer.BLPlans.Plan _blPlan;
        public PlanController()
        {
            _blPlan = new BusinessLogicLayer.BLPlans.Plan();
        }
        //Plan

        [HttpGet]

        public IQueryable? GetAllPlans()
        {
            return _blPlan.GetAll() ?? "not find any plans".AsQueryable();
        }

        [HttpGet("{id}")]
        public IQueryable? GetPlanById(int id)
        {
            return _blPlan.Get(id) ?? $"not find plan with id: {id}!".AsQueryable();
        }

        [HttpPost]
        public IQueryable? CreatePlan([FromQuery] PlanDto planDto,[FromQuery] PlanOptionDto planOptionDto)
        {
            Plan plan = new Plan()
            {
                Name = planDto.Name,
                Status = true
            };
            PlanOption option = new PlanOption()
            {
                CitizenIdType = planOptionDto.CitizenIdType,
                GeneralCreationFlag = planOptionDto.GeneralCreationFlag,
                TurnTimeGap = planOptionDto.TurnTimeGap,
                FromDate = planOptionDto.FromDate,
                ToDate = planOptionDto.ToDate,
                Plan = plan
            };

            _blPlan.Create(plan, option);

            return _blPlan.GetAll() ?? "not find any plans".AsQueryable();
        }

        [HttpPut("{id}")]
        public IQueryable? UpdatePlan(int id,[FromQuery] uPlanDto planDto,[FromQuery] uPlanOptionDto planOptionDto)
        {
            var plan = _blPlan.GetPlan(id);
            
            if (plan != null)
            {
                if (plan.Status == true)
                {
                    plan.Name = planDto.Name ?? plan.Name;

                    var option = _blPlan.GetPlanOption(id);

                    option.CitizenIdType = planOptionDto.CitizenIdType ?? option.CitizenIdType;
                    option.GeneralCreationFlag = planOptionDto.GeneralCreationFlag ?? option.GeneralCreationFlag;
                    option.TurnTimeGap = planOptionDto.TurnTimeGap ?? option.TurnTimeGap;
                    option.FromDate = planOptionDto.FromDate ?? option.FromDate;
                    option.ToDate = planOptionDto.ToDate ?? option.ToDate;

                    _blPlan.Update(id, plan, option);
                }
                else
                {
                    return $"this plan has disabled!".AsQueryable();
                }
            }
            else
            {
                return $"not find plan with id: {id}!".AsQueryable();
            }

            return _blPlan.Get(id);
        }

        [HttpDelete("{id}")]
        public IQueryable? DeletePlan(int id)
        {
            if (_blPlan.IsExist(id))
            {
                _blPlan.Delete(id);
            }
            else
            {
                return $"not find plan with id: {id}!".AsQueryable();
            }

            return _blPlan.GetAll() ?? "not find any plans".AsQueryable();
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
