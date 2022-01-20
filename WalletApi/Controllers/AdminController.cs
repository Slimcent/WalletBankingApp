using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.GobalError;
using Wallet.Entities.Models.CustomerToUser;
using Wallet.Entities.Models.Domain;
using Wallet.Logger;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;

namespace WalletApi.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly ILoggerMessage _logger;
        
        public AdminController(UserManager<User> userManager, IAdminService adminService, IUserService userService, ILoggerMessage logger)
        {
            _userManager = userManager;
            _adminService = adminService;
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("CreateUser")]
        [ServiceFilter(typeof(ModelStateValidation))]
        //[ServiceFilter(typeof(ExistingEmailValidation))]
        public async Task<IActionResult> CreateUser([FromBody] AddUserDto user)
        {
            //var existingEmail = HttpContext.Items["email"] as User;

            var result = await _adminService.Add(user);

            if (!result.Item1.Succeeded)
            {
                foreach (var error in result.Item1.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok(new ErrorDetails {StatusCode = 200, Message = $"User, {user.UserName} was Created Successfully" } );
        }

        [HttpPost("CreateCustomer")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> CreateCustomer([FromBody] AddCustomerDto model)
        {
            var (result, user) = await _adminService.CreateCustomerAsUser(new IdentityModel
            { 
                Email = model.Email, 
                FullName = $"{model.FirstName} {model.LastName}"
            });

            if (result.Succeeded)
            {
                await _adminService.CreateCustomer(user.Id.ToString());

                return Ok(new ErrorDetails { StatusCode = 200, Message = $"User, {user.UserName} was Created Successfully" });
            }
            return BadRequest(ModelState);
        }

        [HttpPost("AddRole")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddRole([FromBody] AddRoleDto model)
        {
            var result = await _adminService.AddRole(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("AddUserToRole")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddUserToRole([FromBody] AddUserToRoleDto model)
        {
            var result = await _adminService.AddUserToRole(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("AddBill")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddBill([FromBody] AddBillDto model)
        {
            var result = await _adminService.AddBill(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("AddAirTime")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddAirTime([FromBody] AddNetworkProviderDto model)
        {
            var result = await _adminService.AddAirTime(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("AddData")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddData([FromBody] AddNetworkProviderDto model)
        {
            var result = await _adminService.AddData(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpGet("GetTotalNumberOfUsers")]
        public IActionResult GetTotalNumberOfUsers()
        {
            var allUsers = _userService.GetTotalNumberOfUsers().Count();

            if (allUsers <= 0)
                return BadRequest(new ErrorDetails { StatusCode = 404, Message = $"0 Users found" });

            return Ok(allUsers + " " + "Users");
        }

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _userService.GetAllUsers();

            if (allUsers.Count() <= 0)
                return BadRequest(new ErrorDetails { StatusCode = 404, Message = $"0 Users found" });

            return Ok(allUsers);
        }

        [HttpGet("GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var allTransactions = await _userService.GetAllTransactions();

            if (allTransactions.Count() <= 0)
                return BadRequest(new ErrorDetails { StatusCode = 404, Message = $"0 Transactiions found" });

            return Ok(allTransactions);
        }

        [HttpPatch("EditUser")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> EditUser(string Id, JsonPatchDocument<PatchUserDto> model)
        {
            var user = await _adminService.EditUser(Id, model);

            if (user.Success)
                return Ok(user.Message);

            return BadRequest(user.Message);
        }

        [HttpPatch("EditRole")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> EditRole(string Id, JsonPatchDocument<PatchRoleDto> model)
        {
            var role = await _adminService.EditRole(Id, model);

            if (role.Success)
                return Ok(role.Message);

            return BadRequest(role.Message);
        }

        [HttpPatch("EditBill")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> EditBill(Guid Id, JsonPatchDocument<PatchBillDto> model)
        {
            var bill = await _adminService.EditBill(Id, model);

            if (bill.Success)
                return Ok(bill.Message);

            return BadRequest(bill.Message);
        }

        [HttpPatch("EditAirtime")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> EditAirTime(Guid Id, JsonPatchDocument<PatchAirTimeDto> model)
        {
            var airTime = await _adminService.EditAirTime(Id, model);

            if (airTime.Success)
                return Ok(airTime.Message);

            return BadRequest(airTime.Message);
        }

        [HttpPatch("EditData")]
        public async Task<IActionResult> EditData(Guid Id, JsonPatchDocument<PatchDataDto> model)
        {
            var data = await _adminService.EditData(Id, model);

            if (data.Success)
                return Ok(data.Message);

            return BadRequest(data.Message);
        }

        [HttpDelete("DeleteUserByEmail")]
        public async Task<IActionResult> DeleteUserByEmail(string email)
        {
            var user = await _adminService.DeleteUserByEmail(email);

            if (user.Success)
                return Ok(user.Message);

            return BadRequest(user.Message);
        }

        [HttpDelete("DeleteRoleByName")]
        public async Task<IActionResult> DeleteRoleByName(string name)
        {
            var role = await _adminService.DeleteRoleByName(name);

            if (role.Success)
                return Ok(role.Message);

            return BadRequest(role.Message);
        }

        [HttpDelete("DeleteBillByName")]
        public async Task<IActionResult> DeleteBillByName(string name)
        {
            var bill = await _adminService.DeleteBillByName(name);

            if (bill.Success)
                return Ok(bill.Message);

            return BadRequest(bill.Message);
        }

        [HttpDelete("DeleteAirTimeByName")]
        public async Task<IActionResult> DeleteAirTimeByName(string name)
        {
            var airTime = await _adminService.DeleteAirTimeByName(name);

            if (airTime.Success)
                return Ok(airTime.Message);

            return BadRequest(airTime.Message);
        }

        [HttpDelete("DeleteDataByName")]
        public async Task<IActionResult> DeleteDataByName(string name)
        {
            var data = await _adminService.DeleteDataByName(name);

            if (data.Success)
                return Ok(data.Message);

            return BadRequest(data.Message);
        }
    }
}
