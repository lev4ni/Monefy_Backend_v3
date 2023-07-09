using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;

namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        //[HttpGet]
        //[ApiVersion("1.0")]
        //public async Task<IActionResult> Login(UserDTO user)
        //{
        //    var userDB = _userAppService.GetUserByIdAsync();
        //}

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
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                userDTO.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
                await _userAppService.CreateUserAsync(userDTO);
                return Ok();
            }
            catch(Exception ex) 
            {
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601) 
                    return BadRequest(new { Success = false, Message = "That name or email already exists." });
                else return BadRequest(new { Success = false, Message = "Error creating user." });    
            }
        }

        [HttpDelete]
        [ApiVersion("1.0")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userAppService.DeleteUserAsync(id);
            return Ok();
        }

    }
}


