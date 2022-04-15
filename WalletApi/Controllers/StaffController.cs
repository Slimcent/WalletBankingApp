using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalError;
using Wallet.Services.Interfaces;

namespace WalletApi.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IStaffService _staffService;
       
        public StaffController(IUserService userService,
           IAccountService accountService, IStaffService staffService)
        {
            _userService = userService;
            _accountService = accountService;
            _staffService = staffService;
        }


        [HttpGet("all-staff")]
        public async Task<IActionResult> GetAllStaff()
        {
            var allStaff = await _staffService.GetAllStaff();

            if (allStaff.Any())
                return Ok(allStaff);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No User found" });
        }


        [HttpGet("staff-by-id")]
        public async Task<IActionResult> GetStaffById(Guid id)
        {
            var staff = await _staffService.GetStaff(id);

            return Ok(staff);
        }

        [HttpPost("create-staff")]
        public async Task<IActionResult> CreateStaff([FromBody] AddUserDto model)
        {
            var staff = await _staffService.CreateStaff(model);

            return Ok(staff);
        }

        [HttpPut("update-staff")]
        public async Task<IActionResult> UpdateteStaff([FromQuery] Guid id, AddressRequestDto model)
        {
            var staff = await _staffService.UpdateStaff(id, model);

            return Ok(staff);
        }


        [HttpGet("total-number-of-staff")]
        public IActionResult GetTotalNumberOfStaff()
        {
            var staff = _staffService.GetTotalNumberOfStaff().Count();

            if (staff <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Staff found" });

            return Ok($"{staff} Staff");
        }

        //[HttpGet("all-customers")]
        //public async Task<IActionResult> GetAllCustomers()
        //{
        //    var allCustomers = await _userService.GetAllCustomers();

        //    if (allCustomers.Any())
        //        return Ok(allCustomers);

        //    return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Customer found" });
        //}

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var Customers = await _userService.GetCustomers();

            if (Customers.Any())
                return Ok(Customers);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Customer found" });
        }

        [HttpGet("all-accounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var allAccounts = await _accountService.GetAccounts();

            if (allAccounts.Any())
                return Ok(allAccounts);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Account found" });
        }

        [HttpGet("user-by-id")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetUserById(id);

            return Ok(result);
        }

        [HttpGet("user-by-email")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userService.GetUserByEmail(email);

            return Ok(result);
        }

        [HttpGet("user-by-wallet-id")]
        public async Task<IActionResult> GetUserByAccount(string walletId)
        {
            var result = await _userService.GetUserByAccountNumber(walletId);

            if(result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpGet("user-by-username")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var result = await _userService.GetByUsernme(username);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpGet("all-transactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var allTransactions = await _userService.GetAllTransactions();

            if (allTransactions.Any())
                return Ok(allTransactions);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Transactiions found" });
        }

        [HttpGet("total-number-of-transactions")]
        public IActionResult GetTotalNumberOfTransactions()
        {
            var numberOfTransactions = _userService.GetTotalNumberOfTransactions().Count();

            if (numberOfTransactions <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Transactiions found" });

            return Ok($"{numberOfTransactions} Transactions");
        }
    }
}
