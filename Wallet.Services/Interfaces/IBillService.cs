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
    public interface IBillService
    {
        Task<Response> AddBill(AddBillDto model);
        Task<Response> EditBill(Guid Id, JsonPatchDocument<PatchBillDto> model);
        Task<Response> DeleteBillByName(string name);
        Task<IEnumerable<AllBillsDto>> GetAllBills();
        IEnumerable<Bill> GetTotalNumberOfBills();
    }
}
