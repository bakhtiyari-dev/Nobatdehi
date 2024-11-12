using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Offices.OfficePlanOption
{
    [ApiController]
    [Route("api/[controller]")]

    public class OfficePlanOptionController : ControllerBase
    {
        private BusinessLogicLayer.BLOffices.OfficePlanOption _blOfficePlanOption;
        public OfficePlanOptionController()
        {
            _blOfficePlanOption = new BusinessLogicLayer.BLOffices.OfficePlanOption();
        }

        [HttpGet("{officeId}/{planId}")]
        public EntityModel.Offices.OfficePlanOption? GetOfficePlanOption(int officeId, int planId)
        {
            opoDto opoDto = new opoDto();
            return _blOfficePlanOption.Get(officeId, planId);
        }

        [HttpGet]
        public List<EntityModel.Offices.OfficePlanOption>? GetOfficePlanOptionList()
        {
            return _blOfficePlanOption.GetAll();
        }

        [HttpPost]
        public IActionResult CreateOfficePlanOption(int officeId, int planId, [FromQuery] opoDto opo)
        {
            EntityModel.Offices.OfficePlanOption officePlanOption = new EntityModel.Offices.OfficePlanOption();

            if (_blOfficePlanOption.Get(officeId, planId) == null)
            {
                officePlanOption.FromDate = opo.FromDate;
                officePlanOption.ToDate = opo.ToDate;
                officePlanOption.Capacity = opo.Capacity;
                officePlanOption.Status = true;

                _blOfficePlanOption.Create(officeId, planId, officePlanOption);
            }

            return Ok("Create");
        }

        [HttpPut]
        public IQueryable? UpdateOfficePlanOption(int officeId, int planId, [FromQuery] uopoDto uopo)
        {
            var officePlan = _blOfficePlanOption.Get(officeId, planId);

            if (officePlan != null)
            {
                if (officePlan.Status)
                {
                    officePlan.FromDate = uopo.FromDate ?? officePlan.FromDate;
                    officePlan.ToDate = uopo.ToDate ?? officePlan.ToDate;
                    officePlan.Capacity = uopo.Capacity ?? officePlan.Capacity;

                    _blOfficePlanOption.Update(officeId, planId, officePlan);
                }
                else
                {
                    return $"this Office Plan Option has disabled!".AsQueryable();
                }
            }
            else
            {
                return $"not find Office Plan Option with id: {officeId}{planId}!".AsQueryable();
            }


            return "Update".AsQueryable();
        }

        [HttpDelete]
        public IQueryable? DeleteOfficePlanOption(int officeId, int planId)
        {
            var officePlan = _blOfficePlanOption.Get(officeId, planId);

            if (officePlan != null)
            {
                _blOfficePlanOption.Delete(officeId, planId);
            }
            else
            {
                return $"not find Office Plan Option with id: {officeId}{planId}!".AsQueryable();
            }

            return "Ok".AsQueryable();
        }
    }
}

