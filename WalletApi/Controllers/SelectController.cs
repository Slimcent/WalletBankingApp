using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Response;
using Wallet.Entities.GobalMessage;
using Wallet.Services.Interfaces;
using Wallet.Services.Services;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectController : BaseController
    {
        private readonly ISelectService _selectService;
        public SelectController(ISelectService selectService)
        {
            _selectService = selectService;
        }

        [HttpGet("all-airTime", Name = "get-all-air-time")]
        public async Task<IActionResult> GetAllAirTime()
        {
            IEnumerable<NetworkProviderResponseDto> response = await _selectService.GetAllAirTime();
            return Ok(response);
        }

        [HttpGet("all-bills", Name = "get-all-bills")]
        public async Task<IActionResult> GetAllBills()
        {
            IEnumerable<BillsResponseDto> response = await _selectService.GetAllBills();
            return Ok(response);
        }

        [HttpGet("all-data", Name = "get-all-data")]
        public async Task<IActionResult> GetAllData()
        {
            IEnumerable<NetworkProviderResponseDto> response = await _selectService.GetAllData();
            return Ok(response);
        }
    }
}