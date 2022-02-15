using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalError;
using Wallet.Entities.Models.Domain;
using Wallet.Logger;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;

namespace WalletApi.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly ILoggerMessage _logger;
        public StaffController(UserManager<User> userManager, IUserService userService,
           IAccountService accountService, ILoggerMessage logger)
        {
            _userManager = userManager;
            _userService = userService;
            _accountService = accountService;
            _logger = logger;
        }

        [HttpGet("GetTotalNumberOfUsers")]
        public IActionResult GetTotalNumberOfUsers()
        {
            var allUsers = _userService.GetTotalNumberOfUsers().Count();

            if (allUsers <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Users found" });

            return Ok(allUsers + " " + "Users");
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _userService.GetAllUsers();

            if (allUsers.Any())
                return Ok(allUsers);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Users found" });
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var allCustomers = await _userService.GetAllCustomers();

            if (allCustomers.Any())
                return Ok(allCustomers);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Customers found" });
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            var allCustomers = await _userService.GetCustomers();

            if (allCustomers.Any())
                return Ok(allCustomers);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Customers found" });
        }

        [HttpGet("GetAllAccounts")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var allAccounts = await _accountService.GetAccounts();

            if (allAccounts.Any())
                return Ok(allAccounts);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Accounts found" });
        }

        [HttpGet("GetUserByID")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await _userService.GetUserById(id);

            return Ok(result);
        }

        [HttpGet("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userService.GetUserByEmail(email);

            return Ok(result);
        }

        [HttpGet("GetUserByWalletID")]
        public async Task<IActionResult> GetUserByAccount(string walletId)
        {
            var result = await _userService.GetUserByAccountNumber(walletId);

            if(result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpGet("GetByUsername")]
        public async Task<IActionResult> GetByUsername(string username)
        {
            var result = await _userService.GetByUsernme(username);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var allTransactions = await _userService.GetAllTransactions();

            if (allTransactions.Any())
                return Ok(allTransactions);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Transactiions found" });
        }

        [HttpGet("GetTotalNumberOfTransactions")]
        public IActionResult GetTotalNumberOfTransactions()
        {
            var numberOfTransactions = _userService.GetTotalNumberOfTransactions().Count();

            if (numberOfTransactions <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Transactiions found" });

            return Ok(numberOfTransactions +" " + "Transactions");
        }

        [HttpGet("Get All Roles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var allRoles = await _userService.GetAllRoles();

            if (allRoles.Any())
                return Ok(allRoles);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Roles found" });
        }

        [HttpGet("Get Total Number of Roles")]
        public IActionResult GetTotalNumberOfRoles()
        {
            var numberOfRoles = _userService.GetTotalNumberOfRoles().Count();

            if (numberOfRoles <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Roles found" });

            return Ok(numberOfRoles + " " + "Roles");
        }

        [HttpGet("Get All Bills")]
        public async Task<IActionResult> GetAllBills()
        {
            var allBills = await _userService.GetAllBills();

            if (allBills.Any())
                return Ok(allBills);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Bills found" });
        }

        [HttpGet("Get Total Number of Bills")]
        public IActionResult GetTotalNumberOfBills()
        {
            var numberOfBills = _userService.GetTotalNumberOfBills().Count();

            if (numberOfBills <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Bills found" });

            return Ok(numberOfBills + " " + "Bills");
        }

        [HttpGet("Get All AirTime")]
        public async Task<IActionResult> GetAllAirTime()
        {
            var allAirTime = await _userService.GetAllAirTime();

            if (allAirTime.Any())
                return Ok(allAirTime);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 AirTime found" });
        }

        [HttpGet("Get Total Number of AirTime")]
        public IActionResult GetTotalNumberOfAirTime()
        {
            var numberOfAirTime = _userService.GetTotalNumberOfAirTime().Count();

            if (numberOfAirTime <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 AirTime found" });

            return Ok(numberOfAirTime + " " + "AirTime");
        }

        [HttpGet("Get All Data")]
        public async Task<IActionResult> GetAllData()
        {
            var allData = await _userService.GetAllData();

            if (allData.Any())
                return Ok(allData);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Data found" });
        }

        [HttpGet("Get Total Number of Data")]
        public IActionResult GetTotalNumberOfData()
        {
            var numberOfData = _userService.GetTotalNumberOfData().Count();

            if (numberOfData <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Data found" });

            return Ok(numberOfData + " " + "Data");
        }
    }
}
