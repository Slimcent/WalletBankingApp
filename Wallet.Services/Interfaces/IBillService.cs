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
    public interface IBillService
    {
        Task<Response> AddBill(AddBillDto model);
        Task<Response> EditBill(Guid Id, JsonPatchDocument<PatchBillDto> model);
        Task<Response> DeleteBillByName(string name);
        Task<IEnumerable<AllBillsDto>> GetAllBills();
        IEnumerable<Bill> GetTotalNumberOfBills();
    }
}
