using Microsoft.AspNetCore.Mvc;
using UIF_API.Models;
using UIF_API.Services;

namespace UIF_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BankController : ControllerBase
    {
        private readonly ILogger<BankController> _logger;
        private readonly IUIFService _uiFService;

        public BankController(ILogger<BankController> logger, IUIFService uiFService)
        {
            _logger = logger;
            _uiFService = uiFService;
        }

        [HttpGet("getallbanks")]
        public async Task<IActionResult> GetAllBanks()
        {
            var banks = await _uiFService.GetAllBanks();
            return Ok(banks);
        }

        [HttpPost("getbranchcode")]
        public async Task<IActionResult> GetBranchCode([FromBody] BranchCodeRequest branchCodeRequest)
        {
            var result = await _uiFService.GetBranchCode(branchCodeRequest);
            return Ok(result);
        }

        [HttpPost("sendbankdetails")]
        public async Task<IActionResult> SendBankDetails([FromBody] SendBankDetailsRequest sendBankDetailsRequest)
        {
            var result = await _uiFService.SendBankDetails(sendBankDetailsRequest);
            return Ok(result);
        }

        [HttpPost("gebankingdetails")]
        public async Task<IActionResult> GeBankingDetails([FromBody] RequestByIdNumber requestByIdNumber)
        {
            var result = await _uiFService.GeBankingDetails(requestByIdNumber);
            return Ok(result);
        }
    }
}
