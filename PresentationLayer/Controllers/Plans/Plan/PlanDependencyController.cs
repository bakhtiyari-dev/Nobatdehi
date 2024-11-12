using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers.Plans.PlanDependency
{
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
        public IQueryable? GetDependency(int id)
        {
            return _blPlan.GetDependency(id) ?? $"Error: not find any dependencies for plan with this id ({id})".AsQueryable();
        }

        [HttpGet("dependency")]
        public IQueryable? GetAllDependencies()
        {
            return _blPlan.GetAllDependencies() ?? $"Error: not find any plan dependencies".AsQueryable();
        }

        [HttpPost("dependency")]
        public IQueryable? CreateDependency(int independentId, int dependentId)
        {
            if (!_blPlan.CheckConflict(independentId, dependentId))
            {
                _blPlan.CreateDependency(independentId, dependentId);
            }
            else
            {
                return $"Error: this action make conflict in dependencies !".AsQueryable();
            }
            return _blPlan.GetDependency(independentId) ?? $"Error: not find any dependencies for plan with this id ({independentId})".AsQueryable();
        }

        [HttpDelete("dependency")]
        public IQueryable? DeleteDependency(int independentId, int dependentId)
        {
            if (_blPlan.CheckExist(independentId, dependentId))
            {
                _blPlan.DeleteDependency(independentId, dependentId);
            }
            else
            {
                return $"Error: Both plans must be available !".AsQueryable();
            }
            return _blPlan.GetAllDependencies() ?? $"Error: not find any plan dependencies".AsQueryable();
        }
    }
}
