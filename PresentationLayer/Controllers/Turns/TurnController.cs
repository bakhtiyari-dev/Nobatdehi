using EntityModel.Turns;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

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
        public TurnController() 
        {
            _blTurn = new BusinessLogicLayer.BLTurns.Turn();
            _blOffice = new BusinessLogicLayer.BLOffices.Office();
            _blPlan = new BusinessLogicLayer.BLPlans.Plan();
            _blCitizen = new BusinessLogicLayer.BLTurns.Citizen();
            _blOpo = new BusinessLogicLayer.BLOffices.OfficePlanOption();
            _blPool = new BusinessLogicLayer.BLTurns.TurnPool();
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
        public IActionResult CreateTurn(TurnDto turnDto)
        {
            var office = _blOffice.Get(turnDto.OfficeId);

            if (office != null) 
            {
                var plan = _blPlan.GetPlan(turnDto.PlanId);

                if (plan != null)
                {
                    var citizen = _blCitizen.Get(turnDto.CitizenId);

                    if (citizen != null)
                    {
                        var turn = new EntityModel.Turns.Turn();

                        turn.PhoneNumber = turnDto.CitizenPhoneNumber;
                        turn.UserId = turnDto.UserId;
                        turn.TurnTime = DateTime.Now;
                        turn.Office = office;
                        turn.Plan = plan;
                        turn.Citizen = citizen;
                        turn.Status = true;

                        _blTurn.Create(turn);
                    }
                    else
                    {
                        Ok("Submited Citizen Not Found!");
                    }
                }
                else
                {
                    Ok("Submited Plan Not Found!");
                }
            }
            else
            {
                Ok("Submited Office Not Found!");
            }


            return Ok("GET ALL");
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
                return Ok(await _blPool.buldturns(opo));
            }

            return NotFound("OPO Was Not Found");
        }
    }


}
