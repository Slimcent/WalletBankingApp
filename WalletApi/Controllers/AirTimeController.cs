using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.Patch;
using Wallet.Entities.Dto.PostDto;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalMessage;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirTimeController : ControllerBase
    {
        private readonly IAirTimeService _airTimeService;
        public AirTimeController(IAirTimeService airTimeService)
        {
            _airTimeService = airTimeService;
        }

        [HttpPost("create-airtime")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddAirTime([FromBody] CreateNetworkProviderDto model)
        {
            var result = await _airTimeService.AddAirTime(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPatch("edit-airtime")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> EditAirTime(Guid Id, JsonPatchDocument<PatchNetworkProviderDto> model)
        {
            var airTime = await _airTimeService.EditAirTime(Id, model);

            if (airTime.Success)
                return Ok(airTime.Message);

            return BadRequest(airTime.Message);
        }

        [HttpDelete("delete-airtime-by-name")]
        public async Task<IActionResult> DeleteAirTimeByName(string name)
        {
            var airTime = await _airTimeService.DeleteAirTimeByName(name);

            if (airTime.Success)
                return Ok(airTime.Message);

            return BadRequest(airTime.Message);
        }

        [HttpGet("all-airTime")]
        public async Task<IActionResult> GetAllAirTime()
        {
            var allAirTime = await _airTimeService.GetAllAirTime();

            if (allAirTime.Any())
                return Ok(allAirTime);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No AirTime found" });
        }

        [HttpGet("total-number-of-airTime")]
        public IActionResult GetTotalNumberOfAirTime()
        {
            var numberOfAirTime = _airTimeService.GetTotalNumberOfAirTime().Count();

            if (numberOfAirTime <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 AirTime found" });

            return Ok($"{numberOfAirTime} AirTime");
        }
    }
}
