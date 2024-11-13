using EntityModel.Turns;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace PresentationLayer.Controllers.Turns.Citizen
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitizenController : ControllerBase
    {
        private BusinessLogicLayer.BLTurns.Citizen _blCitizen;
        public CitizenController()
        {
            _blCitizen = new BusinessLogicLayer.BLTurns.Citizen();
        }

        [HttpGet]
        public List<EntityModel.Turns.Citizen>? GetAllCitizens()
        {
            return _blCitizen.GetAllCitizens();
        }

        [HttpGet("{id}")]
        public List<EntityModel.Turns.Citizen>? GetCitizenById(string id)
        {
            return _blCitizen.GetCitizensById(id);
        }
    }
}
