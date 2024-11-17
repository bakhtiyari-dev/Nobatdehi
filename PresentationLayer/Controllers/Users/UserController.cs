using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using EntityModel.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PresentationLayer.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PresentationLayer.Controllers.Users
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]

    public class UserController : ControllerBase
    {
        private readonly UserManager<CostumIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private BusinessLogicLayer.BLOffices.Office _blOffice;
        private BusinessLogicLayer.Application.ApplicationMethods _application;
        public IEnumerable<CostumIdentityUser> Users { get; set; } = Enumerable.Empty<CostumIdentityUser>();

        public UserController(UserManager<CostumIdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _blOffice = new BusinessLogicLayer.BLOffices.Office();
            _application = new BusinessLogicLayer.Application.ApplicationMethods();
        }

        //private string GenerateJwtToken(string username, string role)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, username),
        //    new Claim(ClaimTypes.Role, role)
        //};

        //    var token = new JwtSecurityToken(
        //        issuer: _configuration["JwtSettings:Issuer"],
        //        audience: _configuration["JwtSettings:Audience"],
        //        claims: claims,
        //        expires: DateTime.Now.AddHours(1),
        //        signingCredentials: credentials
        //    );

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        [HttpGet]
        public IActionResult GetAllUsers([FromQuery] PaginationDto pagination)
        {
            Users = _userManager.Users.ToList();

            var users = _userManager.Users.ToList();

            if (users != null)
            {
                try
                {
                    var result = _application.GetPaginatedResult(users, pagination.PageNumber, pagination.PageSize);
                    return Ok(result);
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            return NotFound("NotFound Any Users");
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

            var office = _blOffice.Get(model.OfficeId);

            if (office != null)
            {
                var roleExist = await _roleManager.RoleExistsAsync(model.Role);
                if (!roleExist)
                {
                    return BadRequest($"Role {model.Role} does not exist");
                }

                var user = new CostumIdentityUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    OfficeId = model.OfficeId,
                    Status = true
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _userManager.AddToRoleAsync(user, model.Role);

                //var token = GenerateJwtToken(user.UserName, model.Role);

                _blOffice.AddUser(model.OfficeId, user);

                return Ok($"User created successfully!\nId: {user.Id}");
            }

            return NotFound("Office Id Was Not Found");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromQuery] UserDto model)
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
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
                return Ok(new { message = "User deleted successfully!" });

            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);

            return BadRequest(ModelState);
        }
    }
}
