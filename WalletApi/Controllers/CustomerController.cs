using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalError;
using Wallet.Entities.Models.CustomerToUser;
using Wallet.Logger;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;

namespace WalletApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        
        public CustomerController(IAdminService adminService, IUserService userService, ILoggerMessage logger)
        {
            _adminService = adminService;
            _userService = userService;
        }

       
        [HttpPost("create-customer")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> CreateCustomer([FromBody] AddUserDto model)
        {
            var customer = await _adminService.CreateCustomer(model);

            return Ok(customer);
        }

        [HttpPost("create-role")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddRole([FromBody] AddRoleDto model)
        {
            var result = await _adminService.AddRole(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("add-user-to-role")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddUserToRole([FromBody] AddUserToRoleDto model)
        {
            var result = await _adminService.AddUserToRole(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

              
        
        [HttpGet("total-number-of-users")]
        public IActionResult GetTotalNumberOfUsers()
        {
            var allUsers = _userService.GetTotalNumberOfUsers().Count();

            if (allUsers <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 User found" });

            return Ok($"{allUsers} Users");
        }

        [HttpGet("all-users")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _userService.GetAllUsers();

            if (allUsers.Any())
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Users found" });

            return Ok(allUsers);
        }

        [HttpGet("all-transactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var allTransactions = await _userService.GetAllTransactions();

            if (allTransactions.Any())
                return Ok(allTransactions);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Transactiions found" });
        }

        [HttpPatch("edit-user")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> EditUser(string Id, JsonPatchDocument<PatchUserDto> model)
        {
            var user = await _adminService.EditUser(Id, model);

            if (user.Success)
                return Ok(user.Message);

            return BadRequest(user.Message);
        }      
        
        [HttpDelete("delete-user-by-email")]
        public async Task<IActionResult> DeleteUserByEmail(string email)
        {
            var user = await _adminService.DeleteUserByEmail(email);

            if (user.Success)
                return Ok(user.Message);

            return BadRequest(user.Message);
        }

        [HttpDelete("delete-role-by-name")]
        public async Task<IActionResult> DeleteRoleByName(string name)
        {
            var role = await _adminService.DeleteRoleByName(name);

            if (role.Success)
                return Ok(role.Message);

            return BadRequest(role.Message);
        }
    }
}
