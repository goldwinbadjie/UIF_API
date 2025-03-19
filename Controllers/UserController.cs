using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using UIF_API.Models;
using UIF_API.Services;

namespace UIF_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IUIFService _uiFService;

        public UserController(ILogger<UserController> logger, IUIFService uiFService)
        {
            _logger = logger;
            _uiFService = uiFService;
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


        [HttpPost("saveforgetpassword")]
        public async Task<IActionResult> SaveForgetPassword([FromBody] ForgotPasswordRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            var registeredUser = await _uiFService.SaveForgetPassword(request);
            return Ok(registeredUser);
        }

        [HttpPost("saveresetpassword")]
        public async Task<IActionResult> SaveResetPassword([FromBody] ResetPasswordRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            var registeredUser = await _uiFService.SaveResetPassword(request);
            return Ok(registeredUser);
        }

        [HttpPost("saveaddressdetails")]
        public async Task<IActionResult> SaveAddressDetails([FromBody] PostalAddress request)
        {
            if (request == null)
            {
                return BadRequest("Invalid data.");
            }

            var response = await _uiFService.SaveAddressDetails(request);
            return Ok(response);
        }


        [HttpGet("getoccupations")]
        public async Task<IActionResult> GetOccupations()
        {
            var response = await _uiFService.GetOccupations();
            return Ok(response);
        }

        [HttpGet("getqualifications")]
        public async Task<IActionResult> GetQualifications()
        {
            var response = await _uiFService.GetQualifications();
            return Ok(response);
        }

    }
}
