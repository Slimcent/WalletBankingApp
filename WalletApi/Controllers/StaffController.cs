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
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;
       
        public StaffController(IStaffService staffService)
        {
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

        [HttpGet("staff-by-email")]
        public async Task<IActionResult> GetStaffByEmail(string email)
        {
            var staff = await _staffService.GetStaffByEmail(email);

            return Ok(staff);
        }

        [HttpPost("create-staff")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> CreateStaff([FromQuery] UsersCreateRequestDto model)
        {
            var staff = await _staffService.CreateStaff(model);

            return Ok(staff);
        }

        [HttpPut("update-staff-address")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> UpdateStaffAddress([FromQuery] Guid staffId, UpdateAddressDto model)
        {
            var staff = await _staffService.UpdateStaffAddress(staffId, model);

            return Ok(staff);
        }

        [HttpPatch("update-staff")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> UpdateStaff(Guid Id, JsonPatchDocument<UpdateStaffDto> model)
        {
            string staff = await _staffService.UpdateStaff(Id, model);

            return Ok(staff);
        }

        [HttpPatch("patch-staff-address")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> PatchStaffAddress(Guid Id, JsonPatchDocument<UpdateAddressDto> model)
        {
            string staff = await _staffService.PatchStaffAddress(Id, model);

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

        [HttpDelete("delete-staff-by-id")]
        public async Task<IActionResult> DeleteStaff([FromQuery] Guid id)
        {
            var staff = await _staffService.DeleteStaffById(id);

            return Ok(staff);
        }

    }
}
