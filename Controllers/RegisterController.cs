using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIF_API.Models;
using UIF_API.Data;

namespace UIF_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;
        private readonly ApplicationDbContext _context;

        public RegisterController(ILogger<RegisterController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPost("login")]
        public IActionResult Login(string id)
        {
            var users = _context.Users.Where(u=>u.deviceId==id);
            return Ok(users);
        }


        // POST: api/YourModel
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody]Users model)
        {
            if (model == null)
            {
                return BadRequest("Invalid data.");
            }

            // Save to the database
            _context.Users.Add(model);
            await _context.SaveChangesAsync();

            return Ok(model);
        }
    }
}
