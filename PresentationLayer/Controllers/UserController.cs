using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using DataAccessLayer;
using Microsoft.AspNetCore.Identity;
using PresentationLayer.DTO;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<CostumIdentityUser> _userManager;
        public IEnumerable<CostumIdentityUser> Users { get; set; } = Enumerable.Empty<CostumIdentityUser>();

        public UserController(UserManager<CostumIdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet] 
        public IEnumerable<CostumIdentityUser> GetAllUsers()
        {
            Users = _userManager.Users.ToList();
            return Users;
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetUsersById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            return Ok("id: " + user.Id + "\nname: " + user.FirstName + " " + user.LastName + "\nusername: " + user.UserName);
        }

        [HttpPost] 
        public async Task<IActionResult> CreateUsers([FromQuery] UserDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new CostumIdentityUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                OfficeId = model.OfficeId,
                Status = true
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                //add user to office user list
                return Ok(new { message = "User created successfully!" });
            }
                
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id,[FromQuery] UserDto model)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound(new { message = "User not found" });

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.UserName = model.UserName;

            if (!string.IsNullOrWhiteSpace(model.Password))
            {

                var removePasswordResult = await _userManager.RemovePasswordAsync(user);
                if (!removePasswordResult.Succeeded)
                {
                    foreach (var error in removePasswordResult.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    return BadRequest(ModelState);
                }

                var addPasswordResult = await _userManager.AddPasswordAsync(user, model.Password);
                if (!addPasswordResult.Succeeded)
                {
                    foreach (var error in addPasswordResult.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                    return BadRequest(ModelState);
                }
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return Ok(new { message = "User updated successfully!" });

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null || user.Status == false)
                return NotFound(new { message = "User not found" });

            user.Status = false;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return Ok(new { message = "User desabled successfully!" });

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return BadRequest(ModelState);
        }
    }
}
