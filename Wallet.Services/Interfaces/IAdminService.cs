using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.IdentityUsers.GetDto;
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
        Task<User> GetUserByID(object Id);
        Task<User> UpdateUser(User user);
        string DeleteUser(string Id);
        string DeleteUser(User user);
    }
}
