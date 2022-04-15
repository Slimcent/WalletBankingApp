using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalError;
using Wallet.Logger;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;

namespace WalletApi.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _adminService;
        private readonly IUserService _userService;
        
        public CustomerController(ICustomerService adminService, IUserService userService, ILoggerMessage logger)
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

        [HttpGet("all-transactions")]
        public async Task<IActionResult> GetAllTransactions()
        {
            var allTransactions = await _userService.GetAllTransactions();

            if (allTransactions.Any())
                return Ok(allTransactions);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Transactiions found" });
        }
    }
}
