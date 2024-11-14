using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;
using System.Globalization;

namespace PresentationLayer.Controllers.Turns.Turn
{
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
        public TurnController()
        {
            _blTurn = new BusinessLogicLayer.BLTurns.Turn();
            _blOffice = new BusinessLogicLayer.BLOffices.Office();
            _blPlan = new BusinessLogicLayer.BLPlans.Plan();
            _blCitizen = new BusinessLogicLayer.BLTurns.Citizen();
            _blOpo = new BusinessLogicLayer.BLOffices.OfficePlanOption();
            _blPool = new BusinessLogicLayer.BLTurns.TurnPool();
            _blWeek = new BusinessLogicLayer.BLOffices.WeekPlan();
        }
        [HttpGet]
        public List<EntityModel.Turns.Turn>? GetAllOTurns()
        {
            return _blTurn.GetAll();
        }

        [HttpGet("{id}")]
        public EntityModel.Turns.Turn? GetTurnById(int id)
        {
            return _blTurn.Get(id);
        }

        [HttpPost]
        public ActionResult<EntityModel.Turns.Turn>? CreateTurn([FromQuery] TurnDto turnDto)
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

                                        DateOnly now = new(persianYear,persianMounth,persianDay+1);

                                        if (now >= officePlan.FromDate && now <= officePlan.ToDate)
                                        {
                                            var turn = new EntityModel.Turns.Turn();

                                            turn.PhoneNumber = turnDto.CitizenPhoneNumber;
                                            turn.UserId = turnDto.UserId;
                                            turn.TurnTime = _blPool.GetTurnTime(now, officePlan);
                                            turn.OfficeId = office.Id;
                                            turn.PlanId = plan.Id;
                                            turn.CitizenId = citizen.Id;
                                            turn.Status = true;

                                            _blTurn.Create(turn, officePlan);

                                            return Ok(turn);
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

        [HttpDelete("{id}")]
        public EntityModel.Turns.Turn? DeleteTurn(int id)
        {
            _blTurn.Delete(id);
            return _blTurn.Get(id);
        }

        // Turn Pool

        [HttpPost("TurnPool")]
        public async Task<IActionResult>? BuildAvailableTurns(int officeId, int planId)
        {
            var opo = _blOpo.Get(officeId, planId);

            if (opo != null)
            {
                if (_blPool.isOpoExist(opo.Id))
                {
                    _blPool.Delete(opo.Id);
                }

                return Ok(await _blPool.buldturns(opo));
            }

            return NotFound("OPO Was Not Found");
        }
    }


}
