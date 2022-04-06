using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IDataService
    {
        Task<Response> AddData(AddNetworkProviderDto model);
        Task<Response> EditData(Guid Id, JsonPatchDocument<PatchDataDto> model);
        Task<Response> DeleteDataByName(string name);
        Task<IEnumerable<AllDataDto>> GetAllData();
        IEnumerable<Entities.Models.Domain.Data> GetTotalNumberOfData();
    }
}
