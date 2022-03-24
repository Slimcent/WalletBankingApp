using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.Models.Domain;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;
using WalletApi.Middlewares;

namespace WalletApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly ITransactionService _transactionService;

        public TransactionController(UserManager<User> userManager, ITransactionService customerService)
        {
            _userManager = userManager;
            _transactionService = customerService;
        }

        [HttpPost("deposit")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> Deposit([FromBody] DepositDto model)
        {
            //var userId = await _userManager.FindByIdAsync(HttpContext.User.GetUserId());

            var result = await _transactionService.Deposit(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("withdraw")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawalDto model)
        {
            //var userId = await _userManager.FindByIdAsync(HttpContext.User.GetUserId());

            var result = await _transactionService.Withdraw(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("transfer")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> Transfer([FromBody] TransferDto model)
        {
            var result = await _transactionService.Transfer(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("pay-bill")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> PayBill([FromBody] PayBillDto model)
        {
            var result = await _transactionService.PayBill(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("buy-airTime")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> BuyAirTime([FromBody] BuyAirTimeDto model)
        {
            var result = await _transactionService.BuyAirTime(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("buy-data")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> BuyData([FromBody] BuyDataDto model)
        {
            var result = await _transactionService.BuyData(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserTransactions(string id)
        {
            //var userId = await _userManager.FindByIdAsync(HttpContext.User.GetUserId());

            var transaction = _transactionService.GetTramsctionByAUser(id);

            return Ok(transaction);



        }


    }
}
