using EntityModel.Offices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers.Plans.PlanCapacity
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CapacityController : Controller
    {
        BusinessLogicLayer.BLPlans.Plan _blPlan;
        BusinessLogicLayer.BLOffices.OfficePlanOption _blOfficePlan;
        public CapacityController()
        {
            _blPlan = new BusinessLogicLayer.BLPlans.Plan();
            _blOfficePlan = new BusinessLogicLayer.BLOffices.OfficePlanOption();
        }

        //Capacity

        [HttpPost]
        public ActionResult<OfficePlanOption>? IncreaseCapacity(int officeId, int planId, int amountToIncrease)
        {
            var officePlan = _blOfficePlan.Get(officeId, planId);

            if (officePlan != null)
            {
                _blPlan.IncreaseCapacity(officePlan.Id, amountToIncrease);

                var result = _blOfficePlan.Get(officeId, planId);
                return Ok(result);
            }

            return NotFound("OPO Was Not Found");
        }

        [HttpPut]
        public ActionResult<OfficePlanOption>? SetCapacity(int officeId, int planId, int amountToSet)
        {
            var officePlan = _blOfficePlan.Get(officeId, planId);

            if (officePlan != null)
            {
                _blPlan.SetCapacity(officePlan.Id, amountToSet);

                return Ok(_blOfficePlan.Get(officeId, planId));
            }

            return NotFound("OPO Was Not Found");
        }

        [HttpDelete]
        public ActionResult<OfficePlanOption>? DecreaseCapacity(int officeId, int planId, int amountToReduce)
        {
            var officePlan = _blOfficePlan.Get(officeId, planId);

            if (officePlan != null)
            {
                _blPlan.DecreaseCapacity(officePlan.Id, amountToReduce);

                return Ok(_blOfficePlan.Get(officeId, planId));
            }

            return NotFound("OPO Was Not Found");
        }
    }
}
