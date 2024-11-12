using EntityModel.Offices;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;
using System.Collections.Immutable;

namespace PresentationLayer.Controllers.Offices
{
    [ApiController]
    [Route("api/[controller]")]

    public class OfficeController : ControllerBase
    {
        private BusinessLogicLayer.BLOffices.Office _blOffice;
        private BusinessLogicLayer.BLOffices.OfficePlanOption _blOfficePlanOption;
        public OfficeController() 
        {
            _blOffice = new BusinessLogicLayer.BLOffices.Office();
            _blOfficePlanOption = new BusinessLogicLayer.BLOffices.OfficePlanOption();
        }

        [HttpGet]
        public List<Office>? GetAllOffices()
        {
            return _blOffice.GetAll();
        }

        [HttpGet("{id}")]
        public Office? GetOfficeById(int id)
        {
            return _blOffice.Get(id);
        }

        [HttpPost]
        public IActionResult CreateOffice([FromQuery] OfficeDto officeDto)
        {
            Office office = new Office()
            {
                City = officeDto.City,
                PhoneNumber = officeDto.PhoneNumber,
                Status = true
            };
            _blOffice.Create(office);
            return Ok("Office was added successfully");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOffice(int id, [FromQuery] OfficeDto officeDto)
        {
            Office office = new Office()
            {
                City = officeDto.City,
                PhoneNumber = officeDto.PhoneNumber,
                Status = true
            };
            _blOffice.Update(id, office);
            return Ok("Office was updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOffice(int id)
        {
            _blOffice.Delete(id);
            return Ok("Office was desabled successfully");
        }

        // Office Plan Option

        [HttpGet("officeOption/{officeId}/{planId}")]
        public OfficePlanOption? GetOfficePlanOption(int officeId, int planId) 
        {
            opoDto opoDto = new opoDto();
            return _blOfficePlanOption.Get(officeId, planId);
        }

        [HttpGet("officeOption")]
        public List<OfficePlanOption>? GetOfficePlanOptionList() 
        {
            return _blOfficePlanOption.GetAll();
        }

        [HttpPost("officeOption")]
        public IActionResult CreateOfficePlanOption(int officeId, int planId,[FromQuery] opoDto opo)
        {
            OfficePlanOption officePlanOption = new OfficePlanOption();

            if (_blOfficePlanOption.Get(officeId, planId) == null) 
            {
                officePlanOption.FromDate = opo.FromDate;
                officePlanOption.ToDate = opo.ToDate;
                officePlanOption.Capacity = opo.Capacity;
                officePlanOption.Status = true;

                _blOfficePlanOption.Create(officeId, planId ,officePlanOption);
            }

            return Ok("Create");
        }

        [HttpPut("officeOption")]
        public IQueryable? UpdateOfficePlanOption(int officeId, int planId,[FromQuery] uopoDto uopo)
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


            return ("Update").AsQueryable();
        }

        [HttpDelete("officeOption")]
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
