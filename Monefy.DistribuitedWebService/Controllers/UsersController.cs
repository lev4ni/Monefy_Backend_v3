using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Monefy.Application.Contracts;
using Monefy.Application.DTOs;
using Org.BouncyCastle.Crypto.Generators;
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
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserAppService userAppService, IConfiguration configuration, ILogger<UsersController> logger)
        {
            _userAppService = userAppService;
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        [TypeFilter(typeof(CustomAuthorizationFilter))]
        public async Task<IActionResult> GetAllUsers()
        {
            var user = await _userAppService.GetAllUsersAsync();
            if (user == null)
            {
                _logger.LogError("No hay usuarios");
                return NotFound();
            }
            _logger.LogInformation($"Usuarios encontrados: {user}");
            return Ok(user);
        }

        [HttpGet("{id}")]
        [ApiVersion("1.0")]
        [TypeFilter(typeof(CustomAuthorizationFilter))]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userAppService.GetUserByIdAsync(id);

            if (user == null)
            {
                _logger.LogError("No hay usuarios");
                return NotFound();
            }
            _logger.LogInformation($"Usuario encontrado: {user}");
            return Ok(user);
        }

        [HttpDelete]
        [ApiVersion("1.0")]
        [TypeFilter(typeof(CustomAuthorizationFilter))]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userAppService.DeleteUserAsync(id);
            _logger.LogInformation($"Usuario eliminado: {id}");
            return Ok();
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
                    var token = GenerateToken(user);
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
                new Claim("expirationTime", DateTime.UtcNow.AddMinutes(10).ToString())
            };

            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60),
                signingCredentials: singIn
            );
            _logger.LogInformation("Token generado con éxito");
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> Register(UserDTO userDTO)
        {
            try
            {
                userDTO.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password);
                await _userAppService.CreateUserAsync(userDTO);
                _logger.LogInformation("Usuario registrado con éxito!");
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


