using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UIF_API.Models;
using Mysqlx;
using static System.Net.Mime.MediaTypeNames;

namespace UIF_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

    }
}
