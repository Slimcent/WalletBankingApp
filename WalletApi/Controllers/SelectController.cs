using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Response;
using Wallet.Services.Interfaces;

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

        [HttpGet("all-bills", Name = "get-all-bills")]
        public async Task<IActionResult> GetAllBills()
        {
            IEnumerable<BillsResponseDto> response = await _selectService.GetAllBills();
            return Ok(response);
        }
    }
}