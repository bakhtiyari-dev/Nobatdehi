using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Turns
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TurnFilterController : ControllerBase
    {
        private BusinessLogicLayer.BLTurns.TurnFilter _blFilter;
        private BusinessLogicLayer.Application.ApplicationMethods _application;
        public TurnFilterController()
        {
            _blFilter = new BusinessLogicLayer.BLTurns.TurnFilter();
            _application = new BusinessLogicLayer.Application.ApplicationMethods();
        }

        [HttpGet("ByDateTime")]
        public ActionResult<List<EntityModel.Turns.Turn>?> GetTurnsByDateTime([FromQuery] PaginationDto pagination, [FromQuery] TurnFilterDto.TurnFilterByDate filterDto)
        {
            var source = _blFilter.GetTurnsByDate(filterDto.FromDate, filterDto.FromHour, filterDto.ToDate, filterDto.ToHour);

            if (source != null)
            {
                try
                {
                    var result = _application.GetPaginatedResult(source, pagination.PageNumber, pagination.PageSize);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("NotFound Any Turns With This Filter");
        }

        [HttpGet("ByPlan")]
        public ActionResult<List<EntityModel.Turns.Turn>?> GetTurnsByPlan([FromQuery] PaginationDto pagination, [FromQuery] TurnFilterDto.TurnFilterByPlan filterDto)
        {
            var source = _blFilter.GetAllTurnsByPlan(filterDto.PlanId);

            if (source != null)
            {
                try
                {
                    var result = _application.GetPaginatedResult(source, pagination.PageNumber, pagination.PageSize);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("NotFound Any Turns With This Filter");
        }

        [HttpGet("ByOffice")]
        public ActionResult<List<EntityModel.Turns.Turn>?> GetTurnsByOffice([FromQuery] PaginationDto pagination, [FromQuery] TurnFilterDto.TurnFilterByOffice filterDto)
        {
            var source = _blFilter.GetAllTurnsByOffice(filterDto.OfficeId);

            if (source != null)
            {
                try
                {
                    var result = _application.GetPaginatedResult(source, pagination.PageNumber, pagination.PageSize);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("NotFound Any Turns With This Filter");
        }

        [HttpGet("ByCitizen")]
        public ActionResult<List<EntityModel.Turns.Turn>?> GetTurnsByCitizen([FromQuery] PaginationDto pagination, [FromQuery] TurnFilterDto.TurnFilterByCitizen filterDto)
        {
            var source = _blFilter.GetAllTurnsByCitizen(filterDto.CitizenId);

            if (source != null)
            {
                try
                {
                    var result = _application.GetPaginatedResult(source, pagination.PageNumber, pagination.PageSize);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("NotFound Any Turns With This Filter");
        }
    }
}
