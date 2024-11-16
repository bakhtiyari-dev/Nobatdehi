using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EntityModel.Users;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private SignInManager<CostumIdentityUser> _signInManager;

        public LoginController(SignInManager<CostumIdentityUser> signInManager)
        {
                _signInManager = signInManager;
        }


        [HttpPost]
        public async Task<IActionResult> LoginUser ([FromQuery] LoginDto login)
        {
            if (!User.Identity.IsAuthenticated)
            {

                var result = await _signInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);

                if (result.Succeeded)
                {
                    return Ok("You have successfully logged in");
                }
                else
                {
                    return BadRequest("The username or password is incorrect!");
                }
            }
            return BadRequest("You are already logged in!");
        }

        [HttpGet]
        public IActionResult LoginStatus () 
        {
            if (Request.Cookies.ContainsKey(".AspNetCore.Identity.Application"))
            {
                return Ok(Request.Cookies[".AspNetCore.Identity.Application"]);
            }
            else
            {
                return Ok("There is no cookie");
            }
        }
    }
}
