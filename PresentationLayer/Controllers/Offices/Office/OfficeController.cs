using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PresentationLayer.DTO;
using static System.Net.Mime.MediaTypeNames;

namespace PresentationLayer.Controllers.Offices.Office
{
    //[Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]

    public class OfficeController : ControllerBase
    {
        private BusinessLogicLayer.BLOffices.Office _blOffice;
        private BusinessLogicLayer.BLOffices.OfficePlanOption _blOfficePlanOption;
        private BusinessLogicLayer.Application.ApplicationMethods _application;
        public OfficeController()
        {
            _blOffice = new BusinessLogicLayer.BLOffices.Office();
            _blOfficePlanOption = new BusinessLogicLayer.BLOffices.OfficePlanOption();
            _application = new BusinessLogicLayer.Application.ApplicationMethods();
        }

        [HttpGet]
        public ActionResult<EntityModel.Offices.Office>? GetAllOffices([FromQuery] PaginationDto pagination)
        {
            var offices = _blOffice.GetAll();

            if (offices != null)
            {
                try
                {
                    var result = _application.GetPaginatedResult(offices, pagination.PageNumber, pagination.PageSize);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("NotFound Any Offices");
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
