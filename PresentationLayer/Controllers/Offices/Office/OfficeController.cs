using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Offices.Office
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
        public ActionResult<EntityModel.Offices.Office>? GetAllOffices()
        {
            return Ok(_blOffice.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<EntityModel.Offices.Office>? GetOfficeById(int id)
        {
            return Ok(_blOffice.Get(id));
        }

        [HttpPost]
        public IActionResult CreateOffice([FromQuery] OfficeDto officeDto)
        {
            EntityModel.Offices.Office office = new EntityModel.Offices.Office()
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
            if (_blOffice.Get(id) != null)
            {
                EntityModel.Offices.Office office = new EntityModel.Offices.Office()
                {
                    City = officeDto.City,
                    PhoneNumber = officeDto.PhoneNumber,
                    Status = true
                };

                _blOffice.Update(id, office);
                return Ok("Office was updated successfully");
            }

            return NotFound("Office Was Not Found");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOffice(int id)
        {
            if(_blOffice.Get(id) != null)
            {
                _blOffice.Delete(id);
                return Ok("Office was desabled successfully");
            }

            return NotFound("Office Was Not Found");
        }
    }
}
