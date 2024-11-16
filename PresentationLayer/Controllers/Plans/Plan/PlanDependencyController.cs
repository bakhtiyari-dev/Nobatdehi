using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers.Plans.PlanDependency
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlanDependencyController : ControllerBase
    {

        private BusinessLogicLayer.BLPlans.Plan _blPlan;
        public PlanDependencyController()
        {
            _blPlan = new BusinessLogicLayer.BLPlans.Plan();
        }


        [HttpGet("dependency/{id}")]
        public ActionResult<IQueryable>? GetDependency(int id)
        {
            var result = _blPlan.GetDependency(id);
            if (result != null) 
            {
                return Ok(result);
            }
            return  NotFound($"not found any dependencies for plan with this id ({id})");
        }

        [HttpGet("dependency")]
        public ActionResult<IQueryable>? GetAllDependencies()
        {
            var result = _blPlan.GetAllDependencies();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound($"not found any dependencies");
        }

        [HttpPost("dependency")]
        public ActionResult<IQueryable>? CreateDependency(int independentId, int dependentId)
        {
            if (!_blPlan.CheckConflict(independentId, dependentId))
            {
                _blPlan.CreateDependency(independentId, dependentId);
            }
            else
            {
                return Conflict("this action make conflict in dependencies");
            }
            return Ok(_blPlan.GetDependency(independentId));
        }

        [HttpDelete("dependency")]
        public ActionResult<IQueryable>? DeleteDependency(int independentId, int dependentId)
        {
            if (_blPlan.CheckExist(independentId, dependentId))
            {
                _blPlan.DeleteDependency(independentId, dependentId);
            }
            else
            {
                return NotFound("Both plans must be available");
            }
            return GetAllDependencies();
        }
    }
}
