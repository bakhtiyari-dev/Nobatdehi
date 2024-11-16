using EntityModel.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Users
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogoutController : Controller
    {
        private SignInManager<CostumIdentityUser> _signInManager;

        public LogoutController(SignInManager<CostumIdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> LoginUser()
        {
            await _signInManager.SignOutAsync();

            return Ok("You have successfully logged out");
        }
    }
}
