using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalMessage;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpPost("create-bill")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddBill([FromBody] CreateBillDto model)
        {
            var result = await _billService.AddBill(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPatch("edit-bill")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> EditBill(Guid Id, JsonPatchDocument<PatchBillDto> model)
        {
            var bill = await _billService.EditBill(Id, model);

            if (bill.Success)
                return Ok(bill.Message);

            return BadRequest(bill.Message);
        }


        [HttpDelete("delete-bill-by-name")]
        public async Task<IActionResult> DeleteBillByName(string name)
        {
            var bill = await _billService.DeleteBillByName(name);

            if (bill.Success)
                return Ok(bill.Message);

            return BadRequest(bill.Message);
        }              

        [HttpGet("total-number-of-bills")]
        public IActionResult GetTotalNumberOfBills()
        {
            var numberOfBills = _billService.GetTotalNumberOfBills().Count();

            if (numberOfBills <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Bills found" });

            return Ok($"{numberOfBills} Bills");
        }
    }
}
