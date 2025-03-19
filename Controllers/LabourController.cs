using Microsoft.AspNetCore.Mvc;
using UIF_API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UIF_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LabourController : ControllerBase
    {
        private readonly ILogger<LabourController> _logger;
        private readonly IUIFService _uiFService;

        public LabourController(ILogger<LabourController> logger, IUIFService uiFService)
        {
            _logger = logger;
            _uiFService = uiFService;
        }

        [HttpGet("getlabourcentres/{dolRegionID}")]
        public async Task<IActionResult> GetLabourCentres(string dolRegionID)
        {
            var response = await _uiFService.GetLabourCentres(dolRegionID);
            return Ok(response);
        }
    }
}
