using Microsoft.AspNetCore.Mvc;
using UIF_API.Models;
using UIF_API.Services;

namespace UIF_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {

        private readonly ILogger<RegisterController> _logger;
        private readonly IUIFService _uiFService;

        public BankController(ILogger<RegisterController> logger, IUIFService uiFService)
        {
            _logger = logger;
            _uiFService = uiFService;
        }

        [HttpGet("getallbanks")]
        public IActionResult GetAllBanks()
        {
            var banks = _uiFService.GetAllBanks();
            return Ok(banks);
        }

        [HttpPost("getbranchcode")]
        public IActionResult GetBranchCode([FromBody] BranchCodeRequest branchCodeRequest)
        {
            var result = _uiFService.GetBranchCode(branchCodeRequest);
            return Ok(result);
        }

        [HttpPost("sendbankdetails")]
        public IActionResult SendBankDetails([FromBody] SendBankDetailsRequest sendBankDetailsRequest)
        {
            var result = _uiFService.SendBankDetails(sendBankDetailsRequest);
            return Ok(result);
        }
    }
}
