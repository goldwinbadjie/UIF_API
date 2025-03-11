using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UIF_API.Data;
using UIF_API.Models;
using UIF_API.Services;

namespace UIF_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IUIFService _uiFService;

        public RegisterController(ILogger<RegisterController> logger, ApplicationDbContext context, IUIFService uiFService)
        {
            _logger = logger;
            _context = context;
            _uiFService = uiFService;
        }

        [Authorize]
        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Models.LoginRequest loginRequest)
        {
            // In a real application, validate the username and password
            if (loginRequest.Username == "testUser" && loginRequest.Password == "testPassword")
            {
                var token = GenerateJwtToken(loginRequest.Username);
                var user = new LoggedInUserViewModel
                {
                    Email = "testUser@gmail.com",
                    Id = "100",
                    Name = "Test",
                    Token = token
                };

                return Ok(user);
            }

            return Unauthorized("Invalid username or password");
        }



        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.SecretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, username)
            }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] UserModel user)
        {

            if (user == null)
            {
                return BadRequest("Invalid data.");
            }

            var resgiteredUser = _uiFService.Registeruser(user);
            return Ok(resgiteredUser);
        }


        [HttpPost("saveForgetPassword")]
        public IActionResult SaveForgetPassword([FromBody] ForgotPasswordRequest request)
        {

            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            var resgiteredUser = _uiFService.SaveForgetPassword(request);
            return Ok(resgiteredUser);
        }


        [HttpPost("saveResetPassword")]
        public IActionResult SaveResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            var resgiteredUser = _uiFService.SaveResetPassword(request);
            return Ok(resgiteredUser);
        }
    }
}
