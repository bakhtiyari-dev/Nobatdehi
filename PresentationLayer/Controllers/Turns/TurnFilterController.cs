using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers.Turns
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TurnFilterController : ControllerBase
    {

        public TurnFilterController()
        {
                
        }


    }
}
