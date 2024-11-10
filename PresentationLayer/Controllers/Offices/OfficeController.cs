using EntityModel.Offices;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Offices
{
    [ApiController]
    [Route("api/[controller]")]

    public class OfficeController : ControllerBase
    {
        [HttpGet]
        public List<Office>? GetAllOffices()
        {
            BusinessLogicLayer.BLOffices.Office blOffice = new BusinessLogicLayer.BLOffices.Office();
            return blOffice.GetAll();
        }

        [HttpGet("{id}")]
        public Office? GetOfficeById(int id)
        {
            BusinessLogicLayer.BLOffices.Office blOffice = new BusinessLogicLayer.BLOffices.Office();
            return blOffice.Get(id);
        }

        [HttpPost]
        public IActionResult CreateOffice([FromQuery] OfficeDto officeDto)
        {
            BusinessLogicLayer.BLOffices.Office blOffice = new BusinessLogicLayer.BLOffices.Office();
            Office office = new Office()
            {
                City = officeDto.City,
                PhoneNumber = officeDto.PhoneNumber,
                Status = true
            };
            blOffice.Create(office);
            return Ok("Office was added successfully");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOffice(int id, [FromQuery] OfficeDto officeDto)
        {
            BusinessLogicLayer.BLOffices.Office blOffice = new BusinessLogicLayer.BLOffices.Office();
            Office office = new Office()
            {
                City = officeDto.City,
                PhoneNumber = officeDto.PhoneNumber,
                Status = true
            };
            blOffice.Update(id, office);
            return Ok("Office was updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOffice(int id)
        {
            BusinessLogicLayer.BLOffices.Office blOffice = new BusinessLogicLayer.BLOffices.Office();
            blOffice.Delete(id);
            return Ok("Office was desabled successfully");
        }
    }
}
