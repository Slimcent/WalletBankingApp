using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.Dto.Request;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IBillService
    {
        Task<Response> AddBill(CreateBillDto model);
        Task<Response> EditBill(Guid Id, JsonPatchDocument<PatchBillDto> model);
        Task<Response> DeleteBillByName(string name);
        IEnumerable<Bill> GetTotalNumberOfBills();
    }
}
