using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.IdentityUsers.Patch;
using Wallet.Entities.Dto.PostDto;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IAirTimeService
    {
        IEnumerable<AirTime> GetTotalNumberOfAirTime();
        Task<Response> DeleteAirTimeByName(string name);
        Task<Response> EditAirTime(Guid Id, JsonPatchDocument<PatchNetworkProviderDto> model);
        Task<Response> AddAirTime(CreateNetworkProviderDto model);
        Task<Response> ToggleAirTimeStatus(Guid airTimeId);
        Task<Response> DeleteAirTimeById(Guid airTimeId);
    }
}
