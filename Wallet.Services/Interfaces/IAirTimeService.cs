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
    public interface IAirTimeService
    {
        IEnumerable<AirTime> GetTotalNumberOfAirTime();
        Task<IEnumerable<AllAirTimeDto>> GetAllAirTime();
        Task<Response> DeleteAirTimeByName(string name);
        Task<Response> EditAirTime(Guid Id, JsonPatchDocument<PatchAirTimeDto> model);
        Task<Response> AddAirTime(AddNetworkProviderDto model);
    }
}
