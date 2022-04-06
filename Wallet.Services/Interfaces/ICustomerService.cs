using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;
using Wallet.Entities.DataTransferObjects;
using Wallet.Entities.DataTransferObjects.IdentityUsers;
using Wallet.Entities.DataTransferObjects.IdentityUsers.Patch;
using Wallet.Entities.GobalMessage;

namespace Wallet.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<string> CreateCustomer(AddUserDto model);
        Task<Response> AddRole(AddRoleDto model);
        Task<Response> AddUserToRole(AddUserToRoleDto model);
        Task<Response> DeleteRole(string name);
        Task<Response> EditUser(string Id, JsonPatchDocument<PatchUserDto> model);
        Task<Response> DeleteUserByEmail(string email);
        Task<Response> DeleteRoleByName(string name);       
        Task<Response> DeleteUserById(string Id);
    }
}
