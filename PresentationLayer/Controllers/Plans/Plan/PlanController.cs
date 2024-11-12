using EntityModel.Plans;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Plans.Plan
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
        public IQueryable? CreatePlan([FromQuery] PlanDto planDto, [FromQuery] PlanOptionDto planOptionDto)
        {
            EntityModel.Plans.Plan plan = new EntityModel.Plans.Plan()
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
        public IQueryable? UpdatePlan(int id, [FromQuery] uPlanDto planDto, [FromQuery] uPlanOptionDto planOptionDto)
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

    }
}
