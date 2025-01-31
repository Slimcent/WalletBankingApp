using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.GobalMessage;

namespace Wallet.Services.Interfaces
{
    public interface IDataService
    {
        Task<Response> AddData(CreateNetworkProviderDto model);
        Task<Response> EditData(Guid Id, JsonPatchDocument<PatchNetworkProviderDto> model);
        Task<Response> DeleteDataByName(string name);
        IEnumerable<Entities.Models.Domain.NetworkData> GetTotalNumberOfData();
    }
}
