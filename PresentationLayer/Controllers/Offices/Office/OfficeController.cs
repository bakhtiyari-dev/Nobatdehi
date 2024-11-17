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
            if (User.Identity.IsAuthenticated)
            {
                var userClims = User.Claims;

                foreach (var item in userClims)
                {
                    if (item.Type.Contains("role"))
                    {
                        if (item.Value.ToUpper() != "ADMIN")
                        {
                            return NotFound("You Are Not Access To This Api");
                        }
                    }
                }
                // Start Controller Code

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

                // End Controller Code
            }
            else
            {
                return NotFound("Can't Find Your Data, Pleas Login Again");
            }

        }

        [HttpGet("{id}")]
        public ActionResult<EntityModel.Offices.Office>? GetOfficeById(int id)
        {

            if (User.Identity.IsAuthenticated)
            {
                var userClims = User.Claims;

                foreach (var item in userClims)
                {
                    if (item.Type.Contains("role"))
                    {
                        if(item.Value.ToUpper() != "ADMIN")
                        {
                            return NotFound("You Are Not Access To This Api");
                        }
                    }
                }

                return Ok(_blOffice.Get(id));
            }
            else
            {
                return NotFound("Can't Find Your Data, Pleas Login Again");
            }   
        }

        [HttpPost]
        public IActionResult CreateOffice([FromQuery] OfficeDto officeDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userClims = User.Claims;

                foreach (var item in userClims)
                {
                    if (item.Type.Contains("role"))
                    {
                        if (item.Value.ToUpper() != "ADMIN")
                        {
                            return NotFound("You Are Not Access To This Api");
                        }
                    }
                }
                // Start Controller Code

                EntityModel.Offices.Office office = new EntityModel.Offices.Office()
                {
                    City = officeDto.City,
                    PhoneNumber = officeDto.PhoneNumber,
                    Status = true
                };
                _blOffice.Create(office);

                return Ok("Office was added successfully");

                // End Controller Code
            }
            else
            {
                return NotFound("Can't Find Your Data, Pleas Login Again");
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateOffice(int id, [FromQuery] OfficeDto officeDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userClims = User.Claims;

                foreach (var item in userClims)
                {
                    if (item.Type.Contains("role"))
                    {
                        if (item.Value.ToUpper() != "ADMIN")
                        {
                            return NotFound("You Are Not Access To This Api");
                        }
                    }
                }
                // Start Controller Code

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

                // End Controller Code
            }
            else
            {
                return NotFound("Can't Find Your Data, Pleas Login Again");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOffice(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userClims = User.Claims;

                foreach (var item in userClims)
                {
                    if (item.Type.Contains("role"))
                    {
                        if (item.Value.ToUpper() != "ADMIN")
                        {
                            return NotFound("You Are Not Access To This Api");
                        }
                    }
                }
                // Start Controller Code

                if (_blOffice.Get(id) != null)
                {
                    _blOffice.Delete(id);
                    return Ok("Office was desabled successfully");
                }

                return NotFound("Office Was Not Found");

                // End Controller Code
            }
            else
            {
                return NotFound("Can't Find Your Data, Pleas Login Again");
            }

        }
    }
}
