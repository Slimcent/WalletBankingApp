using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.Patch;
using Wallet.Entities.Dto.Transaction.PostDto;
using Wallet.Entities.Enumerators;
using Wallet.Entities.GobalMessage;
using Wallet.Services.Interfaces;
using WalletApi.ActionFilters;

namespace WalletApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataService _dataService;

        public DataController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("create-data")]
        [ServiceFilter(typeof(ModelStateValidation))]
        public async Task<IActionResult> AddData([FromBody] AddNetworkProviderDto model)
        {
            var result = await _dataService.AddData(model);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPatch("edit-data")]
        public async Task<IActionResult> EditData(Guid Id, JsonPatchDocument<PatchDataDto> model)
        {
            var data = await _dataService.EditData(Id, model);

            if (data.Success)
                return Ok(data.Message);

            return BadRequest(data.Message);
        }

        [HttpDelete("delete-data-by-name")]
        public async Task<IActionResult> DeleteDataByName(string name)
        {
            var data = await _dataService.DeleteDataByName(name);

            if (data.Success)
                return Ok(data.Message);

            return BadRequest(data.Message);
        }

        [HttpGet("all-data")]
        public async Task<IActionResult> GetAllData()
        {
            var allData = await _dataService.GetAllData();

            if (allData.Any())
                return Ok(allData);

            return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"No Data found" });
        }

        [HttpGet("total-number-of-data")]
        public IActionResult GetTotalNumberOfData()
        {
            var numberOfData = _dataService.GetTotalNumberOfData().Count();

            if (numberOfData <= 0)
                return BadRequest(new ErrorDetails { Status = ResponseStatus.NOT_FOUND, Message = $"0 Data found" });

            return Ok($"{numberOfData} Data");
        }
    }
}
