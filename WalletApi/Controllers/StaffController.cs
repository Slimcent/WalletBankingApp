using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalError;
using Wallet.Entities.Models.Domain;
using Wallet.Logger;
using Wallet.Services.Interfaces;

namespace WalletApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
       
        public StaffController(IUserService userService,
           IAccountService accountService, ILoggerMessage logger)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpGet("total-number-of-users")]
        public IActionResult GetTotalNumberOfUsers()
        {
            var allUsers = _userService.GetTotalNumberOfUsers().Count();

            if (allUsers <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Users found" });

            return Ok($"{allUsers} Users");
        }

        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _userService.GetAllUsers();

            if (allUsers.Any())
                return Ok(allUsers);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No User found" });
        }

        [HttpGet("all-customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var allCustomers = await _userService.GetAllCustomers();

            if (allCustomers.Any())
                return Ok(allCustomers);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Customer found" });
        }

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

        [HttpGet("all-roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var allRoles = await _userService.GetAllRoles();

            if (allRoles.Any())
                return Ok(allRoles);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Roles found" });
        }

        [HttpGet("total-number-of-roles")]
        public IActionResult GetTotalNumberOfRoles()
        {
            var numberOfRoles = _userService.GetTotalNumberOfRoles().Count();

            if (numberOfRoles <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Roles found" });

            return Ok($"{numberOfRoles} Roles");
        }

        [HttpGet("all-bills")]
        public async Task<IActionResult> GetAllBills()
        {
            var allBills = await _userService.GetAllBills();

            if (allBills.Any())
                return Ok(allBills);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Bills found" });
        }

        [HttpGet("total-number-of-bills")]
        public IActionResult GetTotalNumberOfBills()
        {
            var numberOfBills = _userService.GetTotalNumberOfBills().Count();

            if (numberOfBills <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Bills found" });

            return Ok($"{numberOfBills} Bills");
        }

        [HttpGet("all-airTime")]
        public async Task<IActionResult> GetAllAirTime()
        {
            var allAirTime = await _userService.GetAllAirTime();

            if (allAirTime.Any())
                return Ok(allAirTime);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No AirTime found" });
        }

        [HttpGet("total-number-of-airTime")]
        public IActionResult GetTotalNumberOfAirTime()
        {
            var numberOfAirTime = _userService.GetTotalNumberOfAirTime().Count();

            if (numberOfAirTime <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 AirTime found" });

            return Ok($"{numberOfAirTime} AirTime");
        }

        [HttpGet("all-data")]
        public async Task<IActionResult> GetAllData()
        {
            var allData = await _userService.GetAllData();

            if (allData.Any())
                return Ok(allData);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Data found" });
        }

        [HttpGet("total-number-of-data")]
        public IActionResult GetTotalNumberOfData()
        {
            var numberOfData = _userService.GetTotalNumberOfData().Count();

            if (numberOfData <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Data found" });

            return Ok($"{numberOfData} Data");
        }
    }
}
