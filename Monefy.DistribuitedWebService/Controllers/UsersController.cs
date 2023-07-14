using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Monefy.Application.Services;
using Monefy.Infraestructure.DataModels;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Monefy.DistribuitedWebService.Controllers
{
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IConfiguration _configuration;

        public UsersController(IUserAppService userAppService, IConfiguration configuration)
        {
            _userAppService = userAppService;
            _configuration = configuration;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        [TypeFilter(typeof(CustomAuthorizationFilter))]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userAppService.GetAllUsersAsync();
            if (user == null)
            {
                Log.Error("No hay usuarios");
                return NotFound();
            }
            Log.Information($"Usuarios encontrados: {user}");
            return Ok(user);
        }

        [HttpGet("{id}/wallets")]
        [ApiVersion("1.0")]
        [TypeFilter(typeof(CustomAuthorizationFilter))]
        public async Task<IActionResult> GetUserWallets(int id)
        {
            var wallets = await _userAppService.GetUserWallets(id);

            var response = new
            {
                Success = true,
                Message = "User wallets got successfully",
                Data = wallets
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        [TypeFilter(typeof(CustomAuthorizationFilter))]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userAppService.GetUserByIdAsync(id);

            if (user == null)
            {
                Log.Error("No Users yet");
                return NotFound();
            }
            Log.Information($"User : {user}");
            return Ok(user);
        }

        [HttpDelete]
        [ApiVersion("1.0")]
        [TypeFilter(typeof(CustomAuthorizationFilter))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userAppService.DeleteUserAsync(id);
            var response = new
            {
                Success = true,
                Message = "User Deleted successfully",
                Data = user
            };
            Log.Information($"User Deleted: {id}");
            return Ok(response);
        }

        [HttpPost("login")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> login(UserDTO user)
        {
            try
            {
                var userDB = await _userAppService.ExistsUser(user);
                if (BCrypt.Net.BCrypt.Verify(user.Password, userDB.Password))
                {
                    var token = GenerateToken(userDB);
                    return Ok(new
                    {
                        success = true,
                        message = "The login has been succeded.",
                        data = token
                    });
                }
                return Unauthorized(new { Success = false, Message = "The email, name or password is not correct." });
            }
            catch
            {
                return NotFound(new { Success = false, Message = "The user does not exist." });
            }
        }

        private object GenerateToken(UserDTO user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var claims = new List<Claim>()
            {
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Name.ToString()),
                new Claim("email", user.Email.ToString()),
                new Claim("expirationTime", DateTime.Now.AddMinutes(5).ToString())
            };

            var date = DateTime.UtcNow.AddMinutes(5).ToString();

            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: singIn
            );
            Log.Information("Token generado con éxito");
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            // Valida el objeto userDTO utilizando UserDTOValidator
            var validator = new UserDTOValidator();
            var validationResult = await validator.ValidateAsync(userDTO);

            if (!validationResult.IsValid)
            {
                // Si la validación falla, devuelve un BadRequest con los mensajes de error
                var errors = validationResult.Errors.Select(error => error.ErrorMessage);
                return BadRequest(new { Success = false, Message = "Validation error", Errors = errors });
            }

            try
            {
                userDTO.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
                await _userAppService.CreateUserAsync(userDTO);
                Log.Information("Usuario registrado con éxito!");
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2601)
                    return BadRequest(new { Success = false, Message = "That name or email already exists." });
                else return BadRequest(new { Success = false, Message = "Error creating user." });

            }
        }

    }
}


