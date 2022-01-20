using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.DataTransferObjects.Transaction;
using Wallet.Entities.GobalMessage;
using Wallet.Entities.Models.CustomerToUser;
using Wallet.Entities.Models.Domain;

namespace Wallet.Services.Interfaces
{
    public interface IAdminService
    {
        Task<(IdentityResult, User)> Add(AddUserDto user);
        Task<(IdentityResult, User)> CreateCustomerAsUser(IdentityModel model);
        Task<Response> AddRole(AddRoleDto model);
        Task<Response> AddUserToRole(AddUserToRoleDto model);
        Task<Response> DeleteRole(string name);
        Task<Response> AddBill(AddBillDto model);
        Task<Response> AddAirTime(AddNetworkProviderDto model);
        Task<Response> AddData(AddNetworkProviderDto model);
        Task CreateCustomer(string userId);
        Task<Response> EditUser(string Id, JsonPatchDocument<PatchUserDto> model);
        Task<Response> EditRole(string Id, JsonPatchDocument<PatchRoleDto> model);
        Task<Response> EditBill(Guid Id, JsonPatchDocument<PatchBillDto> model);
        Task<Response> EditAirTime(Guid Id, JsonPatchDocument<PatchAirTimeDto> model);
        Task<Response> EditData(Guid Id, JsonPatchDocument<PatchDataDto> model);
        Task<Response> DeleteUserByEmail(string email);
        Task<Response> DeleteRoleByName(string name);
        Task<Response> DeleteBillByName(string name);
        Task<Response> DeleteAirTimeByName(string name);
        Task<Response> DeleteDataByName(string name);
        Task<Response> DeleteUserById(string Id);
    }
}
