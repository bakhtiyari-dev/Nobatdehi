using EntityModel.Turns;
using EntityModel.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;
using System.Globalization;

namespace PresentationLayer.Controllers.Turns.Turn
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class TurnController : ControllerBase
    {
        BusinessLogicLayer.BLTurns.Turn _blTurn;
        BusinessLogicLayer.BLOffices.Office _blOffice;
        BusinessLogicLayer.BLPlans.Plan _blPlan;
        BusinessLogicLayer.BLTurns.Citizen _blCitizen;
        BusinessLogicLayer.BLOffices.OfficePlanOption _blOpo;
        BusinessLogicLayer.BLTurns.TurnPool _blPool;
        BusinessLogicLayer.BLOffices.WeekPlan _blWeek;
        BusinessLogicLayer.BLTurns.DesabledTurn _blDesabledTurn;
        BusinessLogicLayer.Application.ApplicationMethods _application;
        private UserManager<CostumIdentityUser> _userManager;
        public TurnController(UserManager<CostumIdentityUser> userManager)
        {
            _blTurn = new BusinessLogicLayer.BLTurns.Turn();
            _blOffice = new BusinessLogicLayer.BLOffices.Office();
            _blPlan = new BusinessLogicLayer.BLPlans.Plan();
            _blCitizen = new BusinessLogicLayer.BLTurns.Citizen();
            _blOpo = new BusinessLogicLayer.BLOffices.OfficePlanOption();
            _blPool = new BusinessLogicLayer.BLTurns.TurnPool();
            _blWeek = new BusinessLogicLayer.BLOffices.WeekPlan();
            _blDesabledTurn = new BusinessLogicLayer.BLTurns.DesabledTurn();
            _application = new BusinessLogicLayer.Application.ApplicationMethods();
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAllOTurns([FromQuery] PaginationDto pagination)
        {
            var turns = _blTurn.GetAll();

            if (turns != null)
            {
                try
                {
                    var result = _application.GetPaginatedResult(turns, pagination.PageNumber, pagination.PageSize);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("NotFound Any Turns");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntityModel.Turns.Turn?>> GetTurnById(int id)
        {
            string userRole = "";
            string userId = "";

            if (User.Identity.IsAuthenticated)
            {
                var userClims = User.Claims;

                foreach (var item in userClims)
                {
                    if (item.Type.Contains("nameidentifier"))
                    {
                        userId = item.Value;
                    }
                    if (item.Type.Contains("role"))
                    {
                        userRole = item.Value;
                        break;
                    }
                }
            }
            else
            {
                return NotFound("Can't Find Your Data, Pleas Login Again");
            }

            var myUser = await _userManager.FindByIdAsync(userId);

            var turn = _blTurn.Get(id);

            if (turn != null)
            {
                if (turn.OfficeId == myUser.OfficeId || userRole.ToUpper() == "ADMIN")
                {
                    return Ok(turn);
                }
                else
                {
                    return NotFound("You Can't Find Turns That Submited On Other Offices");
                }
            }
            else
            {
                return NotFound($"Not Found Turn With Id: {id}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<EntityModel.Turns.Turn>?> CreateTurn([FromQuery] TurnDto turnDto)
        {
            string userId = "";
            string userRole = "";

            if (User.Identity.IsAuthenticated)
            {
                var userClims = User.Claims;

                foreach (var item in userClims)
                {
                    if (item.Type.Contains("nameidentifier"))
                    {
                        userId = item.Value;
                    }

                    if (item.Type.Contains("role"))
                    {
                        userRole = item.Value;
                        break;
                    }
                }
            }
            else
            {
                return NotFound("Can't Find Your Data, Pleas Login Again");
            }

            var myUser = await _userManager.FindByIdAsync(userId);

            if (myUser.Id == turnDto.UserId)
            {
                var office = _blOffice.Get(turnDto.OfficeId);

                if (office != null && office.Status != false)
                {
                    var plan = _blPlan.GetPlan(turnDto.PlanId);

                    if (plan != null && plan.Status != null)
                    {
                        var citizen = _blCitizen.Get(turnDto.CitizenId);

                        if (citizen != null)
                        {
                            bool repeatedCitizen = _blTurn.IsCitizenExist(turnDto.CitizenId, turnDto.PlanId);

                            if (!repeatedCitizen)
                            {
                                bool checkDependencies = _blTurn.CheckCitizenHasDependencies(turnDto.CitizenId, turnDto.PlanId);

                                if (checkDependencies == true)
                                {
                                    var officePlan = _blOpo.Get(turnDto.OfficeId, turnDto.PlanId);

                                    if (officePlan != null && officePlan.Status != null)
                                    {

                                        if (officePlan.Capacity > 0)
                                        {
                                            var weekPlan = _blWeek.GetWeekPlan(officePlan.Id);

                                            if (weekPlan != null)
                                            {
                                                var planOption = _blPlan.GetPlanOption(turnDto.PlanId);

                                                PersianCalendar persianCalendar = new PersianCalendar();
                                                DateTime dateTime = DateTime.Now;

                                                int persianYear = persianCalendar.GetYear(dateTime);
                                                int persianMounth = persianCalendar.GetMonth(dateTime);
                                                int persianDay = persianCalendar.GetDayOfMonth(dateTime);

                                                DateOnly now = new(persianYear, persianMounth, persianDay + 1);

                                                if (now >= officePlan.FromDate && now <= officePlan.ToDate)
                                                {

                                                    if (myUser.OfficeId == turnDto.OfficeId || (myUser.OfficeId != turnDto.OfficeId && planOption.GeneralCreationFlag == true) || userRole.ToUpper() == "ADMIN")
                                                    {
                                                        var desabledTurn = _blDesabledTurn.GetDesabledTurnsByDate(turnDto.OfficeId, turnDto.PlanId, now);
                                                        
                                                        var turn = new EntityModel.Turns.Turn();

                                                        turn.PhoneNumber = turnDto.CitizenPhoneNumber;
                                                        turn.UserId = turnDto.UserId;
                                                        turn.OfficeId = office.Id;
                                                        turn.PlanId = plan.Id;
                                                        turn.CitizenId = citizen.Id;
                                                        turn.Status = true;

                                                        if (desabledTurn != null)
                                                        {
                                                            turn.TurnTime = now.ToDateTime(desabledTurn.Hour);
                                                            _blDesabledTurn.Delete(desabledTurn.Id);
                                                        }
                                                        else
                                                        {   
                                                            turn.TurnTime = _blPool.GetTurnTime(now, officePlan);
                                                        }

                                                        _blTurn.Create(turn, officePlan);
                                                        _blPlan.DecreaseCapacity(officePlan.Id, 1);

                                                        return Ok("Turn Was Submited Successfully");
                                                    }
                                                    else
                                                    {
                                                        return Conflict("You Can Not Add Turn For Other Offices!");
                                                    }
                                                }
                                                else
                                                {
                                                    return Conflict("Registration Time Of This Office Plan Option Is Over!");
                                                }
                                            }
                                            else
                                            {
                                                return NotFound("The WorkPlan Was Not Found!");
                                            }
                                        }
                                        else
                                        {
                                            return Conflict("The Capacity Of This Plan Is Over!");
                                        }
                                    }
                                    else
                                    {
                                        return NotFound("Office Plan Option Was Not Found!");
                                    }
                                }
                                else
                                {
                                    return Conflict("This Citizen Does Not Have The Prerequisite Courses!");
                                }
                            }
                            else
                            {
                                return Conflict("This Citizen Has Already Chosen This Plan!");
                            }
                        }
                        else
                        {
                            return NotFound("Submited Citizen Was Not Found!");
                        }
                    }
                    else
                    {
                        return NotFound("Submited Plan Was Not Found!");
                    }
                }
                else
                {
                    return NotFound("Submited Office Was Not Found!");
                }
            }
            else
            {
                return NotFound("User Id Is Incorrect");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EntityModel.Turns.Turn?>> DeleteTurn(int id)
        {
            string userRole = "";
            string userId = "";

            if (User.Identity.IsAuthenticated)
            {
                var userClims = User.Claims;

                foreach (var item in userClims)
                {
                    if (item.Type.Contains("nameidentifier"))
                    {
                        userId = item.Value;
                    }
                    if (item.Type.Contains("role"))
                    {
                        userRole = item.Value;
                        break;
                    }
                }
            }
            else
            {
                return NotFound("Can't Find Your Data, Pleas Login Again");
            }

            var myUser = await _userManager.FindByIdAsync(userId);

            var turn = _blTurn.Get(id);

            if (turn != null)
            {
                if (turn.OfficeId == myUser.OfficeId || userRole.ToUpper() == "ADMIN")
                {
                    DateOnly date = DateOnly.FromDateTime(turn.TurnTime);
                    TimeOnly time = TimeOnly.FromDateTime(turn.TurnTime);

                    DesabledTurn desabledTurn = new DesabledTurn()
                    {
                        Day = date,
                        Hour = time,
                        OfficeId = turn.OfficeId,
                        PlanId = turn.PlanId
                    };

                    _blDesabledTurn.Create(desabledTurn);
                    _blTurn.Delete(id);
                    
                    return Ok(turn);
                }
                else
                {
                    return NotFound("You Can't Find Turns That Submited On Other Offices");
                }
            }
            else
            {
                return NotFound($"Not Found Turn With Id: {id}");
            }
        }

        // Turn Pool

        //[HttpPost("TurnPool")]
        //public async Task<IActionResult>? BuildAvailableTurns(int officeId, int planId)
        //{
        //    var opo = _blOpo.Get(officeId, planId);

        //    if (opo != null)
        //    {
        //        if (_blPool.isOpoExist(opo.Id))
        //        {
        //            _blPool.Delete(opo.Id);
        //        }

        //        return Ok(await _blPool.buldturns(opo));
        //    }

        //    return NotFound("OPO Was Not Found");
        //}
    }


}
