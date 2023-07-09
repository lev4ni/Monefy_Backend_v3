using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Implementation;

namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userAppService.GetAllUsersAsync();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userAppService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            await _userAppService.CreateUserAsync(userDTO);
            return Ok();
        }

        [HttpDelete]
        [ApiVersion("1.0")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userAppService.DeleteUserAsync(id);
            return Ok();
        }

        [HttpPost("Register")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            await _userAppService.RegisterUserAsync(userDTO);
            return Ok();
        }

        [HttpPost("login")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Login(UserDTO userDTO)
        {
            var user = await _userAppService.AuthenticateUserAsync(userDTO.Name, userDTO.Password);
            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok(user);
        }
    } 
}


