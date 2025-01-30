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
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet("all-customers")]
        public async Task<IActionResult> GetAllStaff()
        {
            var allcustomers = await _customerService.GetAllCustomers();

            if (allcustomers.Any())
                return Ok(allcustomers);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Customer found" });
        }

        [HttpGet("all-deleted-customers")]
        public async Task<IActionResult> GetAllDeletedStaff()
        {
            var allcustomers = await _customerService.GetAllDeletedCustomers();

            if (allcustomers.Any())
                return Ok(allcustomers);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Deleted Customer found" });
        }

        [HttpGet("customer-by-id")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _customerService.GetCustomer(id);

            return Ok(customer);
        }

        [HttpGet("customer-by-email")]
        public async Task<IActionResult> GetCusstomerByEmail(string email)
        {
            var customer = await _customerService.GetCustomerByEmail(email);

            return Ok(customer);
        }

        [HttpGet("customer-by-walletno")]
        public async Task<IActionResult> GetCusstomerByWalletNo(string walletNo)
        {
            var customer = await _customerService.GetCustomerByWalletNo(walletNo);

            return Ok(customer);
        }

        [HttpPost("create-customer")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> CreateCustomer([FromBody] UsersCreateRequestDto model)
        {
            var customer = await _customerService.CreateCustomer(model);

            return Ok(customer);
        }

        [HttpPatch("update-customer")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> UpdateStaff(Guid Id, JsonPatchDocument<UpdateStaffDto> model)
        {
            string customer = await _customerService.UpdateCustomer(Id, model);

            return Ok(customer);
        }

        [HttpPut("update-customer-address")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> UpdateCustomerAddress([FromQuery] Guid customerId, UpdateAddressDto model)
        {
            var customer = await _customerService.UpdateCustomerAddress(customerId, model);

            return Ok(customer);
        }

        [HttpPatch("patch-customer-address")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> PatchCustomerAddress(Guid Id, JsonPatchDocument<UpdateAddressDto> model)
        {
            string customer = await _customerService.PatchCustomerAddress(Id, model);

            return Ok(customer);
        }

        [HttpPut("undelete-customer")]
        public async Task<IActionResult> UnDeleteCustomer([FromQuery] Guid id)
        {
            var customer = await _customerService.UnDeleteCustomer(id);

            return Ok(customer);
        }

        [HttpDelete("soft-delete-customer")]
        public async Task<IActionResult> SoftDeleteCustomer([FromQuery] Guid id)
        {
            var customer = await _customerService.SoftDeleteCustomer(id);

            return Ok(customer);
        }

        [HttpDelete("delete-customer-by-id")]
        public async Task<IActionResult> DeleteCustomer([FromQuery] Guid id)
        {
            var customer = await _customerService.DeleteCustomerById(id);

            return Ok(customer);
        }
    }
}
