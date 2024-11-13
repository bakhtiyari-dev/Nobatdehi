using EntityModel.Offices;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers.Plans.PlanCapacity
{
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
        public OfficePlanOption? IncreaseCapacity(int officeId, int planId, int amountToIncrease)
        {
            _blPlan.IncreaseCapacity(officeId, planId, amountToIncrease);

            return _blOfficePlan.Get(officeId, planId);
        }

        [HttpPut]
        public OfficePlanOption? SetCapacity(int officeId, int planId, int amountToSet)
        {
            _blPlan.SetCapacity(officeId, planId, amountToSet);

            return _blOfficePlan.Get(officeId, planId);
        }

        [HttpDelete]
        public OfficePlanOption? DecreaseCapacity(int officeId, int planId, int amountToReduce)
        {
            _blPlan.DecreaseCapacity(officeId, planId, amountToReduce);

            return _blOfficePlan.Get(officeId, planId);
        }
    }
}
