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
            if (_blOfficePlan.Get(officeId, planId) != null)
            {
                _blPlan.IncreaseCapacity(officeId, planId, amountToIncrease);
                
                return Ok(_blOfficePlan.Get(officeId, planId));
            }

            return NotFound("OPO Was Not Found");
        }

        [HttpPut]
        public ActionResult<OfficePlanOption>? SetCapacity(int officeId, int planId, int amountToSet)
        {
            if (_blOfficePlan.Get(officeId, planId) != null)
            {
                _blPlan.SetCapacity(officeId, planId, amountToSet);

                return Ok(_blOfficePlan.Get(officeId, planId));
            }

            return NotFound("OPO Was Not Found");
        }

        [HttpDelete]
        public ActionResult<OfficePlanOption>? DecreaseCapacity(int officeId, int planId, int amountToReduce)
        {
            if (_blOfficePlan.Get(officeId, planId) != null)
            {
                _blPlan.DecreaseCapacity(officeId, planId, amountToReduce);

                return Ok(_blOfficePlan.Get(officeId, planId));
            }

            return NotFound("OPO Was Not Found");
        }
    }
}
