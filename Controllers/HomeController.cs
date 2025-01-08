using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIF_API.Models;
using UIF_API.Data;
using Mysqlx;
using static System.Net.Mime.MediaTypeNames;

namespace UIF_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("claims")]
        public IActionResult GetClaims()
        {
            var claims = _context.Claims.ToList();
            return Ok(claims);
        }

        [HttpGet("claim/{id}")]
        public IActionResult GetClaim(int id)
        {
            var claims = _context.Claims.Where(u=>u.ClaimId==id);
            return Ok(claims);
        }

        [HttpPost("ClaimsSave")]
        public async Task<IActionResult> ClaimsSave([FromForm]string RefID, IFormFile idCopy,IFormFile unemployment,IFormFile medicalCert)
        {
            if (string.IsNullOrEmpty(RefID))
            {
                return BadRequest("RefID is required.");
            }

            var model = new Claims
            {
                RefID = RefID
            };

            if (idCopy != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await idCopy.CopyToAsync(memoryStream);
                    model.IDCopy = memoryStream.ToArray(); // 
                }
            }

            if (unemployment != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await unemployment.CopyToAsync(memoryStream);
                    model.Unemployment = memoryStream.ToArray(); 
                }
            }

            if (medicalCert != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await medicalCert.CopyToAsync(memoryStream);
                    model.MedicalCert = memoryStream.ToArray(); 
                }
            }
            try
            {
                _context.Claims.Add(model);
                await _context.SaveChangesAsync();

                return Ok(model);

            }
            catch(Exception ex)
            {
                return StatusCode(400, $"Internal server error: {ex.Message}");
            }

           
        }

        [HttpGet("images/{imageId}")]
        public async Task<IActionResult> GetImage(int imageId)
        {
            // Retrieve the image byte[] from the database
            var imageData =  _context.Claims.Where(i => i.ClaimId == imageId).FirstOrDefault().IDCopy;

            if (imageData == null)
            {
                return NotFound(); // Return 404 if image not found
            }

            return File(imageData, "image/jpeg"); // Adjust MIME type as needed (e.g., image/png, image/jpg)
        }

    }
}
