using EntityModel.Offices;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Offices.OfficeWorkPlan
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeWorkPlanController : ControllerBase
    {
        BusinessLogicLayer.BLOffices.OfficePlanOption _blOpo;
        BusinessLogicLayer.BLOffices.WeekPlan _blWeek;
        public OfficeWorkPlanController()
        {
            _blOpo = new BusinessLogicLayer.BLOffices.OfficePlanOption();
            _blWeek = new BusinessLogicLayer.BLOffices.WeekPlan();
        }


        //Work Plan

        [HttpGet]
        public ActionResult<WeekPlan>? GetWorkPlan(int officeId, int PlanId)
        {
            var opo = _blOpo.Get(officeId, PlanId);

            if (opo != null)
            {
                return Ok(_blWeek.GetWeekPlan(opo.Id));
            }

            return NotFound("Not Found Selected OfficePlan");
        }

        [HttpPost]
        public IActionResult CreateWorkPlan(int officeId, int PlanId,[FromQuery] WeekPlanDto weekPlanDto)
        {
            var opo = _blOpo.Get(officeId, PlanId);


            if (opo != null)
            {
                var check = _blWeek.GetWeekPlan(Convert.ToInt32(officeId.ToString() + PlanId.ToString()));

                if (check == null)
                {
                    WeekPlan weekPlan = new WeekPlan()
                    {
                        SaterdayFirstHour = weekPlanDto.SaterdayFirstHour,
                        SaterdayLasttHour = weekPlanDto.SaterdayLasttHour,

                        SundayFirstHour = weekPlanDto.SundayFirstHour,
                        SundayLasttHour = weekPlanDto.SundayLasttHour,

                        MondayFirstHour = weekPlanDto.MondayFirstHour,
                        MondayLasttHour = weekPlanDto.MondayLasttHour,

                        tuesdayFirstHour = weekPlanDto.tuesdayFirstHour,
                        tuesdayLasttHour = weekPlanDto.tuesdayLasttHour,

                        wednesdayFirstHour = weekPlanDto.wednesdayFirstHour,
                        wednesdayLasttHour = weekPlanDto.wednesdayLasttHour,

                        thursdayFirstHour = weekPlanDto.thursdayFirstHour,
                        thursdayLasttHour = weekPlanDto.thursdayLasttHour,

                        fridayFirstHour = weekPlanDto.fridayFirstHour,
                        fridayLasttHour = weekPlanDto.fridayLasttHour
                    };

                    _blWeek.Create(opo.Id, weekPlan);

                    return Ok("WeekPlan Was Added Seccessfully");
                }
                else
                {
                    return Conflict("There Are WeekPlan For This OfficePlan");
                }
            }
            else
            {
                return NotFound("Not Found Selected OfficePlan");
            }

        }

        [HttpPut]
        public IActionResult UpdateWorkPlan(int officeId, int PlanId,[FromQuery] uWeekPlanDto weekPlanDto)
        {
            var opo = _blOpo.Get(officeId, PlanId);

            if (opo != null)
            {
                var check = _blWeek.GetWeekPlan(Convert.ToInt32(officeId.ToString() + PlanId.ToString()));

                if (check != null)
                {
                    WeekPlan oldWeekPlan = (WeekPlan)check;
                    WeekPlan weekPlan = new WeekPlan()
                    {
                        SaterdayFirstHour = weekPlanDto.SaterdayFirstHour ?? oldWeekPlan.SaterdayFirstHour,
                        SaterdayLasttHour = weekPlanDto.SaterdayLasttHour ?? oldWeekPlan.SundayLasttHour,
                    
                        SundayFirstHour = weekPlanDto.SundayFirstHour ?? oldWeekPlan.SundayFirstHour,
                        SundayLasttHour = weekPlanDto.SundayLasttHour ?? oldWeekPlan.SundayLasttHour,

                        MondayFirstHour = weekPlanDto.MondayFirstHour ?? oldWeekPlan.MondayFirstHour,
                        MondayLasttHour = weekPlanDto.MondayLasttHour ?? oldWeekPlan.MondayLasttHour,

                        tuesdayFirstHour = weekPlanDto.tuesdayFirstHour ?? oldWeekPlan.tuesdayFirstHour,
                        tuesdayLasttHour = weekPlanDto.tuesdayLasttHour ?? oldWeekPlan.tuesdayLasttHour,

                        wednesdayFirstHour = weekPlanDto.wednesdayFirstHour ?? oldWeekPlan.wednesdayFirstHour,
                        wednesdayLasttHour = weekPlanDto.wednesdayLasttHour ?? oldWeekPlan.wednesdayLasttHour,

                        thursdayFirstHour = weekPlanDto.thursdayFirstHour ?? oldWeekPlan.thursdayFirstHour,
                        thursdayLasttHour = weekPlanDto.thursdayLasttHour ?? oldWeekPlan.thursdayLasttHour,

                        fridayFirstHour = weekPlanDto.fridayFirstHour ?? oldWeekPlan.fridayFirstHour,
                        fridayLasttHour = weekPlanDto.fridayLasttHour ?? oldWeekPlan.fridayLasttHour
                    };

                    _blWeek.Update(opo.Id, weekPlan);

                    return Ok("WeekPlan Was Updated Seccessfully");
                }
                else
                {
                    return NotFound("Not Found WeekPlan For This OfficePlan");
                }
            }
            else
            {
                return NotFound("Not Found Selected OfficePlan");
            }
        }

        [HttpDelete]
        public IActionResult DeleteWorkPlan(int officeId, int PlanId)
        {
            var opo = _blOpo.Get(officeId, PlanId);

            if (opo != null)
            {
                var check = _blWeek.GetWeekPlan(opo.Id);

                if (check != null)
                {
                    _blWeek.Delete(check);
                    return Ok("WeekPlan Was Deleted Seccessfully");
                }
                else
                {
                    return NotFound("Not Found WeekPlan For This OfficePlan");
                }
            }
            else
            {
                return NotFound("Not Found Selected OfficePlan");
            }
        }
    }
}
