﻿using Microsoft.AspNetCore.Identity;
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
       
        
        Task CreateCustomer(string userId);
        Task<Response> EditUser(string Id, JsonPatchDocument<PatchUserDto> model);
        Task<Response> EditBill(Guid Id, JsonPatchDocument<PatchBillDto> model);
       
        
        Task<Response> DeleteUserByEmail(string email);
        Task<Response> DeleteRoleByName(string name);
        Task<Response> DeleteBillByName(string name);
        
       
        Task<Response> DeleteUserById(string Id);
    }
}
