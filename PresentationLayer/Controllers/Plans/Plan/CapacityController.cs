using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers.Plans.PlanCapacity
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapacityController : Controller
    {

        public CapacityController()
        {

        }

        //Capacity

        [HttpPost]
        public IActionResult IncreaseCapacity(int officeId, int planId, int amountToIncrease)
        {
            return Ok("Update");
        }

        [HttpPut]
        public IActionResult SetCapacity(int officeId, int planId, int amountToSet)
        {
            return Ok("Update");
        }

        [HttpDelete]
        public IActionResult ReduceCapacity(int officeId, int planId, int amountToReduce)
        {
            return Ok("Update");
        }
    }
}
