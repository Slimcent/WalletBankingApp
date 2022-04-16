using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.Patch;
using Wallet.Entities.Dto.IdentityUsers.Request;
using Wallet.Entities.Dto.Transaction.PostDto;
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
