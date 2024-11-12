using Microsoft.AspNetCore.Mvc;
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
        public List<EntityModel.Offices.Office>? GetAllOffices()
        {
            return _blOffice.GetAll();
        }

        [HttpGet("{id}")]
        public EntityModel.Offices.Office? GetOfficeById(int id)
        {
            return _blOffice.Get(id);
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
            EntityModel.Offices.Office office = new EntityModel.Offices.Office()
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
    }
}
